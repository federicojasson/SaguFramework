using System.Collections.Generic;

namespace SaguFramework {
	
	public static class ObjectManager {
		
		// TODO: usar esta clase para registrar los objetos del mundo

		private static List<Character> characters;
		private static List<InventoryItem> inventoryItems;
		private static List<Item> items;
		private static Loader loader;
		private static Stack<Menu> menus;
		private static PlayerCharacter playerCharacter;
		private static SplashScreen splashScreen;

		static ObjectManager() {
			// Initializes the data structures
			characters = new List<Character>();
			items = new List<Item>();
			inventoryItems = new List<InventoryItem>();
			menus = new Stack<Menu>();
		}

		public static Loader GetLoader() {
			return loader;
		}
		
		public static Menu GetMenu() {
			return menus.Peek();
		}
		
		public static int GetMenuCount() {
			return menus.Count;
		}

		public static SplashScreen GetSplashScreen() {
			return splashScreen;
		}

		public static void RegisterCharacter(Character character) {
			characters.Add(character);
		}

		public static void RegisterInventoryItem(InventoryItem inventoryItem) {
			inventoryItems.Add(inventoryItem);
		}

		public static void RegisterItem(Item item) {
			items.Add(item);
		}

		public static void RegisterLoader(Loader loader) {
			ObjectManager.loader = loader;
		}

		public static void RegisterMenu(Menu menu) {
			menus.Push(menu);
		}

		public static void RegisterPlayerCharacter(PlayerCharacter playerCharacter) {
			ObjectManager.playerCharacter = playerCharacter;
		}

		public static void RegisterSplashScreen(SplashScreen splashScreen) {
			ObjectManager.splashScreen = splashScreen;
		}

		public static void UnregisterCharacter(Character character) {
			characters.Remove(character);
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

		public static void UnregisterPlayerCharacter() {
			playerCharacter = null;
		}

		public static void UnregisterSplashScreen() {
			splashScreen = null;
		}
		
	}
	
}
