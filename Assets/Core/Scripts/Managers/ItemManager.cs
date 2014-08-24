using System.Collections.Generic;

public static class ItemManager {

	private static Dictionary<string, Location> itemLocations;

	static ItemManager() {
		itemLocations = new Dictionary<string, Location>();
	}

	public static void CreateItems(string roomId, Room room) {
		foreach (KeyValuePair<string, Location> entry in itemLocations) {
			Location location = entry.Value;
			
			if (location.RoomId == roomId)
				GameAssets.CreateItem(entry.Key, location.Position, room);
		}
	}

	public static void Reset() {
		itemLocations.Clear();
	}

	public static void SetItemLocation(string id, Location location) {
		itemLocations[id] = location;
	}

}
