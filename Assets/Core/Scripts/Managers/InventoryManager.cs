using System.Collections.Generic;

public static class InventoryManager {

	private static List<InventoryItem> inventoryItems;

	static InventoryManager() {
		inventoryItems = new List<InventoryItem>();
	}

	public static void AddInventoryItem(string id) {
		// Creates the inventory item
		InventoryItem inventoryItem = CreateInventoryItem(id);

		// Adds the inventory item to the list
		inventoryItems.Add(inventoryItem);
	}

	public static void RemoveInventoryItem(InventoryItem inventoryItem) {
		inventoryItems.Remove(inventoryItem);

		// TODO: destroy it?
	}

	public static void Reset() {
		// Clears the manager's data structures
		inventoryItems.Clear();
	}
	
	public static void ShowInventory() {
		// TODO: create background and inventory items
	}

	private static InventoryItem CreateInventoryItem(string id) {
		// TODO
		return null;
	}

}
