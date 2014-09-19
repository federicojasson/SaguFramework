﻿using System.Collections.Generic;

namespace SaguFramework {
	
	public static class Objects {

		private static Dictionary<string, Character> characters;
		private static Inventory inventory;
		private static Dictionary<string, InventoryItem> inventoryItems;
		private static List<InventoryTrigger> inventoryTriggers;
		private static Dictionary<string, Item> items;
		private static Stack<Menu> menus;
		private static Room room;
		private static List<RoomTrigger> roomTriggers;
		private static SplashScreen splashScreen;

		static Objects() {
			characters = new Dictionary<string, Character>();
			inventoryItems = new Dictionary<string, InventoryItem>();
			inventoryTriggers = new List<InventoryTrigger>();
			items = new Dictionary<string, Item>();
			menus = new Stack<Menu>();
			roomTriggers = new List<RoomTrigger>();
		}

		public static Dictionary<string, Character> GetCharacters() {
			return characters;
		}

		public static Inventory GetInventory() {
			return inventory;
		}

		public static Dictionary<string, InventoryItem> GetInventoryItems() {
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
