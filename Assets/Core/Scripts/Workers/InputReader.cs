using UnityEngine;

namespace SaguFramework {

	// TODO: comentar

	public sealed class InputReader : Worker {

		private static InputMode inputMode;
		private static bool isInputLocked;
		private static Order order;
		private static int[] orderIndices;
		private static Order[][] orderSets;
		private static InventoryItem selectedInventoryItem;

		static InputReader() {
			int inputModeCount = Utilities.GetEnumCount<InputMode>();

			orderIndices = new int[inputModeCount];
			for (int i = 0; i < inputModeCount; i++)
				orderIndices[i] = 0;

			orderSets = new Order[inputModeCount][];

			orderSets[(int) InputMode.Inventory] = new Order[] {
				Order.Click,
				Order.Look
			};

			orderSets[(int) InputMode.Locked] = new Order[] {
				Order.None
			};
			
			orderSets[(int) InputMode.Menu] = new Order[] {
				Order.Click
			};
			
			orderSets[(int) InputMode.Room] = new Order[] {
				Order.Walk,
				Order.Look,
				Order.PickUp,
				Order.Speak
			};
			
			orderSets[(int) InputMode.UsingInventoryItem] = new Order[] {};

			inputMode = InputMode.Locked;
			isInputLocked = false;
			order = Order.None;
		}

		public static InputMode GetInputMode() {
			return inputMode;
		}

		public static InventoryItem GetSelectedInventoryItem() {
			return selectedInventoryItem;
		}

		public static void LockInput() {
			isInputLocked = true;
			RefreshInputMode();
		}

		public static void NotifyOnGUI(Entity entity) {
			if (! CanEntityExecute(entity))
				return;

			Drawer.DrawEntity(entity);
		}
		
		public static void NotifyOnMouseEnter(Entity entity) {
			if (! CanEntityExecute(entity))
				return;
			
			if (! IsCursorInGame())
				return;

			entity.GetBehaviour().OnFocus();
		}

		public static void NotifyOnMouseExit(Entity entity) {
			if (! CanEntityExecute(entity))
				return;
			
			if (! IsCursorInGame())
				return;

			entity.GetBehaviour().OnDefocus();
		}

		public static void NotifyOnMouseUpAsButton(Entity entity) {
			if (! CanEntityExecute(entity))
				return;
			
			if (! IsCursorInGame())
				return;
			
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
					float x = CameraHandler.ScreenToWorldPosition(Input.mousePosition).x;
					entity.GetBehaviour().OnWalk(x);
					break;
				}
			}
		}

		public static void NotifyOnTriggerEnter2D(Entity entity, Collider2D collider) {
			if (! CanEntityExecute(entity))
				return;
			
			Character character = Utilities.GetComponent<Character>(collider);
			if (character == null)
				return;
			
			entity.GetBehaviour().OnCharacterEnter(character);
		}

		public static void RefreshInputMode() {
			if (isInputLocked) {
				SetInputMode(InputMode.Locked);
				return;
			}
			
			if (Objects.GetMenus().Count > 0) {
				SetInputMode(InputMode.Menu);
				return;
			}
			
			if (order == Order.UseInventoryItem) {
				SetInputMode(InputMode.UsingInventoryItem);
				return;
			}
			
			Inventory inventory = Objects.GetInventory();
			if (inventory != null && inventory.IsActivated()) {
				SetInputMode(InputMode.Inventory);
				return;
			}
			
			if (Objects.GetRoom() != null) {
				SetInputMode(InputMode.Room);
				return;
			}
			
			SetInputMode(InputMode.Locked);
		}
		
		public static void SelectInventoryItem(InventoryItem inventoryItem) {
			selectedInventoryItem = inventoryItem;
			SetOrder(Order.UseInventoryItem);
		}

		public static void UnlockInput() {
			isInputLocked = false;
			RefreshInputMode();
		}
		
		public static void UnselectInventoryItem() {
			selectedInventoryItem = null;
			SetOrder(Order.None);
		}
		
		private static bool AnyKeyWasPressed(KeyCode[] keys) {
			foreach (KeyCode key in keys)
				if (Input.GetKeyDown(key))
					return true;
			
			return false;
		}

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
		
		private static void CheckInputInventory() {
			TryPauseGame();
			TrySetNextOrder();
			TrySetPreviousOrder();
			TryToggleInventory();
		}
		
		private static void CheckInputMenu() {
			TryCloseMenu();
			TrySetNextOrder();
			TrySetPreviousOrder();
		}
		
		private static void CheckInputRoom() {
			TryPauseGame();
			TrySetNextOrder();
			TrySetPreviousOrder();
			TryToggleInventory();
		}
		
		private static void CheckInputUsingInventoryItem() {
			TryPauseGame();
			TryToggleInventory();
			TryUnselectInventoryItem();
		}

		private static bool IsCursorInGame() {
			Rect gameRectangle = Geometry.GetGameRectangleInScreen();
			return gameRectangle.Contains(Input.mousePosition);
		}

		private static void SetInputMode(InputMode inputMode) {
			if (InputReader.inputMode != inputMode) {
				InputReader.inputMode = inputMode;

				if (inputMode == InputMode.UsingInventoryItem)
					return;

				int orderIndex = orderIndices[(int) inputMode];
				SetOrder(orderSets[(int) inputMode][orderIndex]);

				Drawer.ClearTooltip();
				foreach (Character character in Objects.GetCharacters().Values)
					if (character.IsActivated())
						character.StopActions();
			}
		}
		
		private static void SetNextOrder() {
			Order[] orderSet = orderSets[(int) inputMode];
			
			int orderIndex = orderIndices[(int) inputMode];
			orderIndex = (orderIndex + 1) % orderSet.Length;
			orderIndices[(int) inputMode] = orderIndex;
			
			SetOrder(orderSet[orderIndex]);
		}

		private static void SetOrder(Order order) {
			if (InputReader.order != order) {
				InputReader.order = order;

				Drawer.SetCursor(order);
				RefreshInputMode();
			}
		}
		
		private static void SetPreviousOrder() {
			Order[] orderSet = orderSets[(int) inputMode];

			int orderIndex = orderIndices[(int) inputMode];
			orderIndex = (orderIndex - 1 + orderSet.Length) % orderSet.Length;
			orderIndices[(int) inputMode] = orderIndex;

			SetOrder(orderSet[orderIndex]);
		}
		
		private static void TryCloseMenu() {
			if (AnyKeyWasPressed(Parameters.GetCloseMenuKeys()))
				MenuManager.CloseMenu();
		}
		
		private static void TryPauseGame() {
			if (AnyKeyWasPressed(Parameters.GetPauseGameKeys()))
				MenuManager.OpenPauseMenu();
		}
		
		private static void TrySetNextOrder() {
			if (AnyKeyWasPressed(Parameters.GetSetNextOrderKeys()))
				SetNextOrder();
			
			if (Parameters.UseMouseWheel() && Input.GetAxis(Parameters.AxisNameScrollWheel) > 0)
				SetNextOrder();
		}
		
		private static void TrySetPreviousOrder() {
			if (AnyKeyWasPressed(Parameters.GetSetPreviousOrderKeys()))
				SetPreviousOrder();
			
			if (Parameters.UseMouseWheel() && Input.GetAxis(Parameters.AxisNameScrollWheel) < 0)
				SetPreviousOrder();
		}
		
		private static void TryToggleInventory() {
			if (AnyKeyWasPressed(Parameters.GetToggleInventoryKeys()))
				InventoryManager.ToggleInventory();
		}
		
		private static void TryUnselectInventoryItem() {
			if (AnyKeyWasPressed(Parameters.GetUnselectInventoryItemKeys()))
				UnselectInventoryItem();

			if (! Parameters.UseMouseWheel())
				return;

			if (Input.GetAxis(Parameters.AxisNameScrollWheel) < 0)
				UnselectInventoryItem();

			if (Input.GetAxis(Parameters.AxisNameScrollWheel) > 0)
				UnselectInventoryItem();
		}

		public void OnLevelWasLoaded(int level) {
			isInputLocked = false;
			RefreshInputMode();
		}
		
		public void Update() {
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
