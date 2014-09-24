using UnityEngine;

namespace SaguFramework {

	/// This worker has a major role in the game's logic.
	/// It's responsible of handling the entity's events and reading the user's input.
	/// Keeping track of the game's state, it decides whether to allow the events according to this state.
	/// Also, it handles the orders the user can give and the use of inventory items.
	public sealed class InputReader : Worker {

		private static InputMode inputMode; // The current input mode
		private static bool isInputManuallyLocked; // Determines whether input is manually locked
		private static Order order; // The current order
		private static int[] orderIndices; // Keeps track of the order index in each order set
		private static Order[][] orderSets; // The order sets: there is one per input mode
		private static InventoryItem selectedInventoryItem; // The selected inventory item

		/// Performs class initialization tasks.
		static InputReader() {
			inputMode = InputMode.Locked;
			isInputManuallyLocked = false;
			order = Order.None;

			// Gets the amount of input modes
			int inputModeCount = Utilities.GetEnumCount<InputMode>();

			// Initializes the order indices and order sets for each input mode
			orderIndices = new int[inputModeCount];
			orderSets = new Order[inputModeCount][];

			orderIndices[(int) InputMode.Inventory] = 0; // Initially: Order.Click
			orderSets[(int) InputMode.Inventory] = new Order[] {
				Order.Click,
				Order.Look
			};

			orderIndices[(int) InputMode.Locked] = 0;
			orderSets[(int) InputMode.Locked] = new Order[] {
				Order.None
			};

			orderIndices[(int) InputMode.Menu] = 0;
			orderSets[(int) InputMode.Menu] = new Order[] {
				Order.Click
			};

			orderIndices[(int) InputMode.Room] = 3; // Initially: Order.Walk
			orderSets[(int) InputMode.Room] = new Order[] {
				Order.Look,
				Order.PickUp,
				Order.Speak,
				Order.Walk
			};
			
			orderIndices[(int) InputMode.UsingInventoryItem] = 0;
			orderSets[(int) InputMode.UsingInventoryItem] = new Order[] {};
		}

		/// Gets the current input mode.
		public static InputMode GetInputMode() {
			return inputMode;
		}

		/// Gets the selected inventory item.
		/// It returns null if there isn't one.
		public static InventoryItem GetSelectedInventoryItem() {
			return selectedInventoryItem;
		}

		/// Locks the input manually.
		/// The caller is responsible of calling UnlockInput to unlock the input.
		public static void LockInput() {
			isInputManuallyLocked = true;

			// Refreshes the input mode according to the state of the game
			RefreshInputMode();
		}

		/// Notifies that the received entity's OnGUI method was invoked.
		public static void NotifyOnGUI(Entity entity) {
			if (! CanEntityExecute(entity))
				// The entity isn't allowed to execute in the current state of the game
				return;

			// Draws the entity
			Drawer.DrawEntity(entity);
		}

		/// Notifies that the received entity's OnMouseEnter method was invoked.
		public static void NotifyOnMouseEnter(Entity entity) {
			if (! CanEntityExecute(entity))
				// The entity isn't allowed to execute in the current state of the game
				return;
			
			if (! IsCursorInGame())
				// The cursor is not in the game's area, so the action is ignored
				return;

			// Invokes the appropriate behaviour's callback method
			entity.GetBehaviour().OnFocus();
		}

		/// Notifies that the received entity's OnMouseExit method was invoked.
		public static void NotifyOnMouseExit(Entity entity) {
			if (! CanEntityExecute(entity))
				// The entity isn't allowed to execute in the current state of the game
				return;
			
			if (! IsCursorInGame())
				// The cursor is not in the game's area, so the action is ignored
				return;

			// Invokes the appropriate behaviour's callback method
			entity.GetBehaviour().OnDefocus();
		}

		/// Notifies that the received entity's OnMouseUpAsButton method was invoked.
		public static void NotifyOnMouseUpAsButton(Entity entity) {
			if (! CanEntityExecute(entity))
				// The entity isn't allowed to execute in the current state of the game
				return;
			
			if (! IsCursorInGame())
				// The cursor is not in the game's area, so the action is ignored
				return;

			// Invokes the appropriate behaviour's callback method, according to the current order
			switch (order) {
				case Order.Click : {
					entity.GetBehaviour().OnClick();
					break;
				}
					
				case Order.Look : {
					entity.GetBehaviour().OnLook();
					break;
				}
					
				case Order.PickUp : {
					entity.GetBehaviour().OnPickUp();
					break;
				}
					
				case Order.Speak : {
					entity.GetBehaviour().OnSpeak();
					break;
				}
					
				case Order.UseInventoryItem : {
					entity.GetBehaviour().OnUseInventoryItem(selectedInventoryItem);
					break;
				}
					
				case Order.Walk : {
					// Gets the X value in world space of the cursor's position
					float x = CameraHandler.ScreenToWorldPosition(Input.mousePosition).x;
					
					entity.GetBehaviour().OnWalk(x);
					break;
				}
			}
		}

		/// Notifies that the received entity's OnTriggerEnter2D method was invoked.
		public static void NotifyOnTriggerEnter2D(Entity entity, Collider2D collider) {
			if (! CanEntityExecute(entity))
				// The entity isn't allowed to execute in the current state of the game
				return;
			
			Character character = Utilities.GetComponent<Character>(collider);
			if (character == null)
				// The colliding object isn't a character
				return;
			
			// Invokes the appropriate behaviour's callback method
			entity.GetBehaviour().OnCharacterEnter(character);
		}

		/// Checks the state of the game and automatically sets the appropriate input mode.
		public static void RefreshInputMode() {
			if (isInputManuallyLocked) {
				// The input was locked manually
				SetInputMode(InputMode.Locked);
				return;
			}
			
			if (Entities.GetMenus().Count > 0) {
				// There is an opened menu
				SetInputMode(InputMode.Menu);
				return;
			}
			
			if (order == Order.UseInventoryItem) {
				// The current order is to use an inventory item
				SetInputMode(InputMode.UsingInventoryItem);
				return;
			}
			
			Inventory inventory = Entities.GetInventory();
			if (inventory != null && inventory.IsActivated()) {
				// The inventory is being shown
				SetInputMode(InputMode.Inventory);
				return;
			}
			
			if (Entities.GetRoom() != null) {
				// There is a room in the scene
				SetInputMode(InputMode.Room);
				return;
			}

			// If none of the above cases holds, the input gets locked
			SetInputMode(InputMode.Locked);
		}

		/// Selects an inventory item.
		public static void SelectInventoryItem(InventoryItem inventoryItem) {
			selectedInventoryItem = inventoryItem;

			// Sets the order to use the inventory item
			SetOrder(Order.UseInventoryItem);
		}
		
		/// Unlocks the input.
		/// This method must be called sometime after invoking LockInput.
		public static void UnlockInput() {
			isInputManuallyLocked = false;

			// Refreshes the input mode according to the state of the game
			RefreshInputMode();
		}
		
		/// Unselects the currently selected inventory item.
		public static void UnselectInventoryItem() {
			selectedInventoryItem = null;

			// Unsets the current order
			SetOrder(Order.None);
		}
		
		/// Determines whether any of the received keys was pressed.
		private static bool AnyKeyWasPressed(KeyCode[] keys) {
			foreach (KeyCode key in keys)
				if (Input.GetKeyDown(key))
					// The key was pressed
					return true;

			// None of the keys was pressed
			return false;
		}

		/// Determines whether the received entity is allowed to execute in the current state of the game.
		/// This decision is made based on the current input mode and the type of entity that it is.
		private static bool CanEntityExecute(Entity entity) {
			switch (inputMode) {
				case InputMode.Inventory : {
					if (entity is InventoryItem)
						return true;
					
					if (entity is InventoryTrigger)
						return true;
					
					return false;
				}
					
				case InputMode.Menu : {
					if (entity is Menu)
						return true;
					
					return false;
				}
					
				case InputMode.Room : {
					if (entity is Character)
						return true;
					
					if (entity is Item)
						return true;

					if (entity is Room)
						return true;
					
					if (entity is RoomTrigger)
						return true;
					
					return false;
				}
					
				case InputMode.UsingInventoryItem : {
					if (entity is Character)
						return true;
					
					if (entity is InventoryItem)
						return true;
					
					if (entity is InventoryTrigger)
						return true;
					
					if (entity is Item)
						return true;
					
					if (entity is Room)
						return true;
					
					if (entity is RoomTrigger)
						return true;
					
					return false;
				}
					
				default : {
					return false;
				}
			}
		}

		/// Input-checking method when the current input mode is Inventory.
		private static void CheckInputInventory() {
			TryPauseGame();
			TrySetNextOrder();
			TrySetPreviousOrder();
			TryToggleInventory();
		}

		/// Input-checking method when the current input mode is Menu.
		private static void CheckInputMenu() {
			TryCloseMenu();
			TrySetNextOrder();
			TrySetPreviousOrder();
		}

		/// Input-checking method when the current input mode is Room.
		private static void CheckInputRoom() {
			TryPauseGame();
			TrySetNextOrder();
			TrySetPreviousOrder();
			TryToggleInventory();
		}

		/// Input-checking method when the current input mode is UsingInventoryItem.
		private static void CheckInputUsingInventoryItem() {
			TryPauseGame();
			TryToggleInventory();
			TryUnselectInventoryItem();
		}

		/// Determines whether the cursor is in the game's area.
		private static bool IsCursorInGame() {
			// Gets the game's rectangle in screen space
			Rect gameRectangle = Geometry.GetGameRectangleInScreen();

			// Checks if the cursor's position is contained in the rectangle
			return gameRectangle.Contains(Input.mousePosition);
		}
		
		/// Sets the current input mode.
		/// Based on the new input mode, updates the current order and performs other tasks.
		private static void SetInputMode(InputMode inputMode) {
			if (InputReader.inputMode != inputMode) {
				// The input mode is actually changed

				// Sets the new input mode
				InputReader.inputMode = inputMode;

				if (inputMode == InputMode.UsingInventoryItem)
					// This input mode is set only when the order is changed to UseInventoryItem, so there is no need to
					// update the current order
					return;

				// Updates the order based on the current index in the corresponding order set
				int orderIndex = orderIndices[(int) inputMode];
				SetOrder(orderSets[(int) inputMode][orderIndex]);

				// Clears the tooltip
				Drawer.ClearTooltip();

				// Stops the actions of all the active characters in the room
				foreach (Character character in Entities.GetCharacters().Values)
					if (character.IsActivated())
						character.StopActions();
			}
		}

		/// Sets the next order in the current order set.
		private static void SetNextOrder() {
			// Gets the current order set
			Order[] orderSet = orderSets[(int) inputMode];

			// Updates the order index
			int orderIndex = orderIndices[(int) inputMode];
			orderIndex = (orderIndex + 1) % orderSet.Length;
			orderIndices[(int) inputMode] = orderIndex;

			// Sets the order
			SetOrder(orderSet[orderIndex]);
		}
		
		/// Sets the current order.
		/// Also, refreshes the input mode and performs other tasks.
		private static void SetOrder(Order order) {
			if (InputReader.order != order) {
				// The order is actually changed
				
				// Sets the new order
				InputReader.order = order;

				// Sets the cursor's texture according to the new order
				Drawer.SetCursor(order);

				// Refreshes the input mode according to the state of the game
				RefreshInputMode();
			}
		}

		/// Sets the previous order in the current order set.
		private static void SetPreviousOrder() {
			// Gets the current order set
			Order[] orderSet = orderSets[(int) inputMode];

			// Updates the order index
			int orderIndex = orderIndices[(int) inputMode];
			orderIndex = (orderIndex - 1 + orderSet.Length) % orderSet.Length;
			orderIndices[(int) inputMode] = orderIndex;

			// Sets the order
			SetOrder(orderSet[orderIndex]);
		}

		/// Tries to close the menu.
		private static void TryCloseMenu() {
			if (AnyKeyWasPressed(Parameters.GetCloseMenuKeys()))
				MenuManager.CloseMenu();
		}

		/// Tries to pause the menu.
		private static void TryPauseGame() {
			if (AnyKeyWasPressed(Parameters.GetPauseGameKeys()))
				MenuManager.OpenPauseMenu();
		}

		/// Tries to set the next order.
		private static void TrySetNextOrder() {
			if (AnyKeyWasPressed(Parameters.GetSetNextOrderKeys()))
				SetNextOrder();
			
			if (Parameters.UseMouseWheel() && Input.GetAxis(Parameters.AxisNameScrollWheel) > 0)
				SetNextOrder();
		}

		/// Tries to set the previous order.
		private static void TrySetPreviousOrder() {
			if (AnyKeyWasPressed(Parameters.GetSetPreviousOrderKeys()))
				SetPreviousOrder();
			
			if (Parameters.UseMouseWheel() && Input.GetAxis(Parameters.AxisNameScrollWheel) < 0)
				SetPreviousOrder();
		}

		/// Tries to toggle the inventory.
		private static void TryToggleInventory() {
			if (AnyKeyWasPressed(Parameters.GetToggleInventoryKeys()))
				InventoryManager.ToggleInventory();
		}

		/// Tries to unselect the inventory item.
		private static void TryUnselectInventoryItem() {
			if (AnyKeyWasPressed(Parameters.GetUnselectInventoryItemKeys()))
				UnselectInventoryItem();

			if (! Parameters.UseMouseWheel())
				// The mouse wheel is deactivated
				return;

			if (Input.GetAxis(Parameters.AxisNameScrollWheel) < 0)
				UnselectInventoryItem();

			if (Input.GetAxis(Parameters.AxisNameScrollWheel) > 0)
				UnselectInventoryItem();
		}

		public void OnLevelWasLoaded(int level) {
			isInputManuallyLocked = false;

			// Refreshes the input mode according to the state of the game
			RefreshInputMode();
		}
		
		public void Update() {
			// Invokes the appropriate input-checking method, according to the current input mode
			switch (inputMode) {
				case InputMode.Inventory : {
					CheckInputInventory();
					break;
				}
					
				case InputMode.Menu : {
					CheckInputMenu();
					break;
				}
					
				case InputMode.Room : {
					CheckInputRoom();
					break;
				}
					
				case InputMode.UsingInventoryItem : {
					CheckInputUsingInventoryItem();
					break;
				}
			}
		}

	}
	
}
