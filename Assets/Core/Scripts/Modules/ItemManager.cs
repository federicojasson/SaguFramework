using System.Collections.Generic;
using UnityEngine;

public static class ItemManager {

	private static Dictionary<string, Item> items;
	
	static ItemManager() {
		items = new Dictionary<string, Item>();
	}

	public static void AddItem(Item item) {
		items.Add(item.GetId(), item);
		
		// TODO: check errors?
	}

	public static void LoadRoomItems(string room) {
		foreach (Item item in items.Values)
			if (item.GetRoom().Equals(room)) {
				// The item is in the room
				
				// Creates the item game object and attaches it to the item
				GameObject gameObject = Factory.CreateItem(item);
				item.SetGameObject(gameObject);
			}

		// TODO: check errors?
	}
	
	public static void RemoveItem(string id) {
		items.Remove(id);
		
		// TODO: check errors?
	}

}
