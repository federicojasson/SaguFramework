using System.Collections.Generic;

namespace SaguFramework {
	
	public static class Objects {

		private static List<Character> characters;
		private static Inventory inventory;
		private static List<InventoryItem> inventoryItems;
		private static List<Item> items;
		private static Loader loader;
		private static Stack<Menu> menus;
		private static Character playerCharacter;
		private static Room room;
		private static SplashScreen splashScreen;

		static Objects() {
			characters = new List<Character>();
			inventoryItems = new List<InventoryItem>();
			items = new List<Item>();
			menus = new Stack<Menu>();
		}
		
		public static Menu GetCurrentMenu() {
			return menus.Peek();
		}

		public static Inventory GetInventory() {
			return inventory;
		}

		public static List<InventoryItem> GetInventoryItems() {
			return inventoryItems;
		}

		public static Loader GetLoader() {
			return loader;
		}

		public static int GetMenuCount() {
			return menus.Count;
		}

		public static Character GetPlayerCharacter() {
			if (playerCharacter == null) {
				string playerCharacterId = State.GetPlayerCharacterId();

				foreach (Character character in characters)
					if (character.GetId() == playerCharacterId)
						playerCharacter = character;
			}

			return playerCharacter;
		}

		public static Room GetRoom() {
			return room;
		}

		public static SplashScreen GetSplashScreen() {
			return splashScreen;
		}

		public static void RegisterCharacter(Character character) {
			characters.Add(character);
		}

		public static void RegisterInventory(Inventory inventory) {
			Objects.inventory = inventory;
		}

		public static void RegisterInventoryItem(InventoryItem inventoryItem) {
			inventoryItems.Add(inventoryItem);
		}

		public static void RegisterItem(Item item) {
			items.Add(item);
		}

		public static void RegisterLoader(Loader loader) {
			Objects.loader = loader;
		}
		
		public static void RegisterMenu(Menu menu) {
			menus.Push(menu);
		}
		
		public static void RegisterRoom(Room room) {
			Objects.room = room;
		}

		public static void RegisterSplashScreen(SplashScreen splashScreen) {
			Objects.splashScreen = splashScreen;
		}

		public static void UnregisterCharacter(Character character) {
			characters.Remove(character);
		}

		public static void UnregisterInventory() {
			inventory = null;
		}

		public static void UnregisterInventoryItem(InventoryItem inventoryItem) {
			inventoryItems.Remove(inventoryItem);
		}

		public static void UnregisterItem(Item item) {
			items.Remove(item);
		}

		public static void UnregisterLoader() {
			loader = null;
		}
		
		public static void UnregisterMenu() {
			menus.Pop();
		}
		
		public static void UnregisterRoom() {
			room = null;
		}

		public static void UnregisterSplashScreen() {
			splashScreen = null;
		}

	}
	
}
