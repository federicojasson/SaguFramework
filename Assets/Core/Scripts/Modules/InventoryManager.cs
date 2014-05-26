using System.Collections.Generic;

//
// InventoryManager - Module class
//
// TODO: write class description
//
public static class InventoryManager {

	private static Dictionary<string, InventoryItem> items;

	static InventoryManager() {
		items = new Dictionary<string, InventoryItem>();
	}

	public static void AddItem(InventoryItem item) {
		items.Add(item.GetId(), item);
	}

	public static void RemoveItem(string id) {
		items.Remove(id);
	}

}
