using System.Collections.Generic;
using UnityEngine;

//
// ItemManager - Module class
//
// TODO: write class description
//
public static class ItemManager {

	private static Dictionary<string, Item> items;
	
	static ItemManager() {
		items = new Dictionary<string, Item>();
	}

	public static void AddItem(Item item) {
		items.Add(item.GetId(), item);
	}

	public static void CreateRoomItems(string room) {
		foreach (Item item in items.Values)
			if (item.GetRoom().Equals(room)) {
				// The item is in the room
				
				// Creates the item game object and attaches it to the item
				GameObject gameObject = Factory.CreateItem(item);
				item.SetGameObject(gameObject);
			}
	}
	
	public static void RemoveItem(string id) {
		items.Remove(id);
	}

}
