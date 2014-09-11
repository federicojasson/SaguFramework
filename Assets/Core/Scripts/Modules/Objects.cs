using System.Collections.Generic;

namespace SaguFramework {
	
	public static class Objects {

		private static Dictionary<string, Character> characters;
		private static Inventory inventory;
		private static List<InventoryItem> inventoryItems;
		private static List<InventoryTrigger> inventoryTriggers;
		private static Dictionary<string, Item> items;
		private static Stack<Menu> menus;
		private static Room room;
		private static List<RoomTrigger> roomTriggers;
		private static SplashScreen splashScreen;
		private static List<Worker> workers;

		static Objects() {
			characters = new Dictionary<string, Character>();
			inventoryItems = new List<InventoryItem>();
			inventoryTriggers = new List<InventoryTrigger>();
			items = new Dictionary<string, Item>();
			menus = new Stack<Menu>();
			roomTriggers = new List<RoomTrigger>();
			workers = new List<Worker>();
		}

		public static Dictionary<string, Character> GetCharacters() {
			return characters;
		}

		public static Inventory GetInventory() {
			return inventory;
		}

		public static List<InventoryItem> GetInventoryItems() {
			return inventoryItems;
		}

		public static List<InventoryTrigger> GetInventoryTriggers() {
			return inventoryTriggers;
		}

		public static Dictionary<string, Item> GetItems() {
			return items;
		}
		
		public static Stack<Menu> GetMenus() {
			return menus;
		}

		public static Room GetRoom() {
			return room;
		}

		public static List<RoomTrigger> GetRoomTriggers() {
			return roomTriggers;
		}

		public static SplashScreen GetSplashScreen() {
			return splashScreen;
		}
		
		public static List<Worker> GetWorkers() {
			return workers;
		}

		public static void RegisterEntity(Entity entity) {
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
				inventoryItems.Add((InventoryItem) entity);
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

		public static void RegisterWorker(Worker worker) {
			workers.Add(worker);
		}

		public static void UnregisterEntity(Entity entity) {
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
				inventoryItems.Remove((InventoryItem) entity);
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

		public static void UnregisterWorker(Worker worker) {
			workers.Remove(worker);
		}

	}
	
}
