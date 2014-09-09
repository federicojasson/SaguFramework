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
			
			if (! ScreenHandler.IsCursorInGame())
				return;
			
			entity.GetBehaviour().OnFocus();
		}
		
		public static void NotifyOnMouseExit(Entity entity) {
			if (! CanEntityExecute(entity))
				return;
			
			if (! ScreenHandler.IsCursorInGame())
				return;
			
			entity.GetBehaviour().OnDefocus();
		}
		
		public static void NotifyOnMouseUpAsButton(Entity entity) {
			if (! CanEntityExecute(entity))
				return;
			
			if (! ScreenHandler.IsCursorInGame())
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
			
			if (Utilities.GetComponent<Character>(collider) != Objects.GetPlayerCharacter())
				return;
			
			entity.GetBehaviour().OnPlayerCharacterEnter();
		}

		private static bool CanEntityExecute(Entity entity) {
			Type type = entity.GetType();
			
			switch (GameHandler.GetGameMode()) {
				case GameMode.Inventory : {
					// TODO: faltan los botones y el close
					
					if (type == typeof(InventoryItem))
						return true;
					
					return false;
				}
					
				case GameMode.Menu : {
					// TODO: ?
					
					if (type == typeof(Menu))
						return true;
					
					return false;
				}
					
				case GameMode.Playing : {
					if (type == typeof(Character))
						return true;
					
					if (type == typeof(Item))
						return true;
					
					if (type == typeof(Trigger))
						return true;
					
					return false;
				}
					
				case GameMode.UsingInventoryItem : {
					// TODO
					
					
					return false;
				}

				case GameMode.Waiting : {
					return false;
				}
					
				default : {
					return false;
				}
			}
		}

	}
	
}
