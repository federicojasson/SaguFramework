using System;
using UnityEngine;

namespace SaguFramework {
	
	public class InputHandler : Worker {

		public static Vector2 GetMousePositionInScreen() {
			return Input.mousePosition;
		}

		public static Vector2 GetMousePositionInWorld() {
			Vector2 position = GetMousePositionInScreen();
			return CameraHandler.ScreenToWorldPosition(position);
		}

		public static void NotifyOnGUI(Entity entity) {
			if (! CanEntityExecute(entity))
				return;
			
			entity.GetBehaviour().OnShowGui();
		}
		
		public static void NotifyOnMouseEnter(Entity entity) {
			if (! CanEntityExecute(entity))
				return;
			
			if (! GraphicHandler.IsCursorInGame())
				return;
			
			entity.GetBehaviour().OnFocus();
		}
		
		public static void NotifyOnMouseExit(Entity entity) {
			if (! CanEntityExecute(entity))
				return;
			
			if (! GraphicHandler.IsCursorInGame())
				return;
			
			entity.GetBehaviour().OnDefocus();
		}
		
		public static void NotifyOnMouseUpAsButton(Entity entity) {
			if (! CanEntityExecute(entity))
				return;

			if (! GraphicHandler.IsCursorInGame())
				return;

			switch (OrderHandler.GetOrder()) {
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
					InventoryItem inventoryItem = OrderHandler.GetSelectedInventoryItem();
					entity.GetBehaviour().OnUseInventoryItem(inventoryItem);
					break;
				}
					
				case Order.Walk : {
					Vector2 position = InputHandler.GetMousePositionInWorld();
					entity.GetBehaviour().OnWalk(position);
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
		
		private static bool AnyKeyWasPressed(KeyCode[] keys) {
			foreach (KeyCode key in keys)
				if (Input.GetKeyDown(key))
					return true;
			
			return false;
		}

		private static bool CanEntityExecute(Entity entity) {
			switch (GameHandler.GetGameMode()) {
				case GameMode.Inventory : {
					if (entity is InventoryItem)
						return true;

					if (entity is InventoryTrigger)
						return true;
					
					return false;
				}
					
				case GameMode.Menu : {
					if (entity is Menu)
						return true;
					
					return false;
				}
					
				case GameMode.Playing : {
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
					
				case GameMode.UsingInventoryItem : {
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
		
		private static void CheckInputPlaying() {
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

		private static void TryCloseMenu() {
			if (AnyKeyWasPressed(Parameters.GetCloseMenuKeys()))
				MenuHandler.CloseMenu();
		}

		private static void TryPauseGame() {
			if (AnyKeyWasPressed(Parameters.GetPauseGameKeys()))
				MenuHandler.OpenPauseMenu();
		}

		private static void TrySetNextOrder() {
			if (AnyKeyWasPressed(Parameters.GetSetNextOrderKeys()))
				OrderHandler.SetNextOrder();

			if (Parameters.UseMouseWheel() && Input.GetAxis(Parameters.AxisNameScrollWheel) > 0)
				OrderHandler.SetNextOrder();
		}

		private static void TrySetPreviousOrder() {
			if (AnyKeyWasPressed(Parameters.GetSetPreviousOrderKeys()))
				OrderHandler.SetPreviousOrder();

			if (Parameters.UseMouseWheel() && Input.GetAxis(Parameters.AxisNameScrollWheel) < 0)
				OrderHandler.SetPreviousOrder();
		}
		
		private static void TryToggleInventory() {
			if (AnyKeyWasPressed(Parameters.GetToggleInventoryKeys()))
				InventoryHandler.ToggleInventory();
		}

		private static void TryUnselectInventoryItem() {
			if (AnyKeyWasPressed(Parameters.GetUnselectInventoryItemKeys()))
				OrderHandler.UnselectInventoryItem();
		}

		public void Update() {
			switch (GameHandler.GetGameMode()) {
				case GameMode.Inventory : {
					CheckInputInventory();
					break;
				}
				
				case GameMode.Menu : {
					CheckInputMenu();
					break;
				}
				
				case GameMode.Playing : {
					CheckInputPlaying();
					break;
				}
					
				case GameMode.UsingInventoryItem : {
					CheckInputUsingInventoryItem();
					break;
				}
			}
		}

	}
	
}
