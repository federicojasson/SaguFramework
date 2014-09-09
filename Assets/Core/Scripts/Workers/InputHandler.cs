using System;
using UnityEngine;

namespace SaguFramework {
	
	public class InputHandler : Worker {
		
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
					Vector2 position = new Vector2(0, 0); // TODO: calculate
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

	}
	
}
