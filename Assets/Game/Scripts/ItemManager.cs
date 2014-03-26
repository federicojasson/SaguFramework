using System.Collections.Generic;

public static class ItemManager {

	private static Dictionary<string, Item> items;

	public static List<Item> GetRoomItems(string roomId) {
		List<Item> roomItems = new List<Item>();

		foreach (Item item in items.Values)
			if (item.GetRoomId().Equals(roomId))
				roomItems.Add(item);
		
		return roomItems;
	}

	public static void LoadItems() {
		// TODO
	}

}
