using System.Collections.Generic;

public static class ItemManager {

	private static Dictionary<string, Location> itemLocations;
	private static List<Item> roomItems;

	static ItemManager() {
		itemLocations = new Dictionary<string, Location>();
		roomItems = new List<Item>();
	}

	public static void Reset() {
		// Clears the manager's data structures
		itemLocations.Clear();
		roomItems.Clear();
	}

}
