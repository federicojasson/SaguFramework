using System.Collections.Generic;

public static class Inventory {

	private static Dictionary<string, InventoryItem> items;

	static Inventory() {
		items = new Dictionary<string, InventoryItem>();
	}

	public static void AddItem(InventoryItem item) {
		items.Add(item.GetId(), item);

		// TODO: check errors?
	}

	public static void RemoveItem(string id) {
		items.Remove(id);

		// TODO: check errors?
	}

}
