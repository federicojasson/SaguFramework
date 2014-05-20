using System.Collections.Generic;

public static class ItemManager {

	private static Dictionary<string, Item> items;
	
	static ItemManager() {
		items = new Dictionary<string, Item>();
	}

	public static void AddItem(Item item) {
		items.Add(item.GetId(), item);
		
		// TODO: check errors?
	}
	
	public static void RemoveItem(string id) {
		items.Remove(id);
		
		// TODO: check errors?
	}

}
