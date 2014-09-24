using System.Collections.Generic;

namespace SaguFramework {

	/// Keeps track of the entities of the game.
	/// The entities register themselves with this module at creation and unregister when they are destroyed.
	/// This module offers convenient methods to access the entities statically.
	public static class Entities {

		private static Dictionary<string, Character> characters; // The characters
		private static Inventory inventory; // The inventory
		private static Dictionary<string, InventoryItem> inventoryItems; // The inventory items
		private static List<InventoryTrigger> inventoryTriggers; // The inventory triggers
		private static Dictionary<string, Item> items; // The items
		private static Stack<Menu> menus; // The menus
		private static Room room; // The room
		private static List<RoomTrigger> roomTriggers; // The room triggers
		private static SplashScreen splashScreen; // The splash screen

		/// Performs class initialization tasks.
		static Entities() {
			characters = new Dictionary<string, Character>();
			inventoryItems = new Dictionary<string, InventoryItem>();
			inventoryTriggers = new List<InventoryTrigger>();
			items = new Dictionary<string, Item>();
			menus = new Stack<Menu>();
			roomTriggers = new List<RoomTrigger>();
		}

		/// Returns the characters.
		public static Dictionary<string, Character> GetCharacters() {
			return characters;
		}

		/// Returns the inventory.
		public static Inventory GetInventory() {
			return inventory;
		}

		/// Returns the inventory items.
		public static Dictionary<string, InventoryItem> GetInventoryItems() {
			return inventoryItems;
		}

		/// Returns the inventory triggers.
		public static List<InventoryTrigger> GetInventoryTriggers() {
			return inventoryTriggers;
		}

		/// Returns the items.
		public static Dictionary<string, Item> GetItems() {
			return items;
		}
		
		/// Returns the menus.
		public static Stack<Menu> GetMenus() {
			return menus;
		}
		
		/// Returns the room.
		public static Room GetRoom() {
			return room;
		}
		
		/// Returns the room triggers.
		public static List<RoomTrigger> GetRoomTriggers() {
			return roomTriggers;
		}

		/// Returns the splash screen.
		public static SplashScreen GetSplashScreen() {
			return splashScreen;
		}
		
		/// Registers an entity.
		/// The entity must be fully initialized before calling this method.
		public static void RegisterEntity(Entity entity) {
			// Detects what kind of entity it is and takes the proper action

			if (entity is Character) {
				Character character = (Character) entity;
				characters.Add(character.GetId(), character);
				return;
			}
			
			if (entity is Inventory) {
				inventory = (Inventory) entity;
				return;
			}
			
			if (entity is InventoryItem) {
				InventoryItem inventoryItem = (InventoryItem) entity;
				inventoryItems.Add(inventoryItem.GetId(), inventoryItem);
				return;
			}
			
			if (entity is InventoryTrigger) {
				inventoryTriggers.Add((InventoryTrigger) entity);
				return;
			}
			
			if (entity is Item) {
				Item item = (Item) entity;
				items.Add(item.GetId(), item);
				return;
			}
			
			if (entity is Menu) {
				menus.Push((Menu) entity);
				return;
			}
			
			if (entity is Room) {
				room = (Room) entity;
				return;
			}
			
			if (entity is RoomTrigger) {
				roomTriggers.Add((RoomTrigger) entity);
				return;
			}
			
			if (entity is SplashScreen) {
				splashScreen = (SplashScreen) entity;
				return;
			}
		}
		
		/// Unregisters an entity.
		public static void UnregisterEntity(Entity entity) {
			// Detects what kind of entity it is and takes the proper action

			if (entity is Character) {
				Character character = (Character) entity;
				characters.Remove(character.GetId());
				return;
			}
			
			if (entity is Inventory) {
				inventory = null;
				return;
			}
			
			if (entity is InventoryItem) {
				InventoryItem inventoryItem = (InventoryItem) entity;
				inventoryItems.Remove(inventoryItem.GetId());
				return;
			}
			
			if (entity is InventoryTrigger) {
				inventoryTriggers.Remove((InventoryTrigger) entity);
				return;
			}
			
			if (entity is Item) {
				Item item = (Item) entity;
				items.Remove(item.GetId());
				return;
			}
			
			if (entity is Menu) {
				menus.Pop();
				return;
			}
			
			if (entity is Room) {
				room = null;
				return;
			}
			
			if (entity is RoomTrigger) {
				roomTriggers.Remove((RoomTrigger) entity);
				return;
			}
			
			if (entity is SplashScreen) {
				splashScreen = null;
				return;
			}
		}

	}
	
}
