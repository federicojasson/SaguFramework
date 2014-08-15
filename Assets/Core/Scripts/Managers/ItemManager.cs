using System.Collections.Generic;
using UnityEngine;

public static class ItemManager {
	
	private static List<Item> activeItems;
	private static Dictionary<string, Location> itemLocations;
	private static ItemManagerWorker worker;

	static ItemManager() {
		activeItems = new List<Item>();
		itemLocations = new Dictionary<string, Location>();
	}
	
	public static void ClearState() {
		itemLocations.Clear();
	}

	public static void CreateRoomItems(string room) {
		activeItems.Clear();

		foreach (KeyValuePair<string, Location> entry in itemLocations) {
			Location location = entry.Value;

			if (location.Room == room)
				activeItems.Add(CreateItem(entry.Key, location.Position));
		}
	}

	public static void SetItemLocation(string id, Location location) {
		itemLocations.Add(id, location);
	}

	public static void SetWorker(ItemManagerWorker worker) {
		ItemManager.worker = worker;
	}
	
	private static Item CreateItem(string id, Vector2 position) {
		// TODO: a change of position's coordinates might be necessary

		Item itemModel = worker.ItemModels[id];
		return (Item) Object.Instantiate(itemModel, position, Quaternion.identity);
	}

}
