using System.Collections.Generic;

public static class ItemManager {

	private static Dictionary<string, Location> itemLocations;

	static ItemManager() {
		itemLocations = new Dictionary<string, Location>();
	}

	public static void CreateItems(string roomId) {
		foreach (KeyValuePair<string, Location> entry in itemLocations) {
			Location location = entry.Value;
			
			if (location.RoomId == roomId)
				GameAssets.CreateItem(entry.Key, location.Position);
		}
	}

	public static void Reset() {
		// Clears the manager's data structures
		itemLocations.Clear();
	}

}
