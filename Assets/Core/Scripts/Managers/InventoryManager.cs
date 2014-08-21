using System.Collections.Generic;

public static class InventoryManager {

	private static List<InventoryItem> inventoryItems;

	static InventoryManager() {
		inventoryItems = new List<InventoryItem>();
	}

	public static void Reset() {
		inventoryItems.Clear();
	}

}
