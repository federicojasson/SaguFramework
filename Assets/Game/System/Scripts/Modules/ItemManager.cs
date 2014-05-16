using System.Collections.Generic;

public static class ItemManager {

	private static List<InventoryItem> inventoryItems;
	private static List<RoomItem> roomItems;

	static ItemManager() {
		inventoryItems = new List<InventoryItem>();
		roomItems = new List<RoomItem>();
	}
	
	public static void AddInventoryItem(InventoryItem inventoryItem) {
		inventoryItems.Add(inventoryItem);
	}
	
	public static void AddRoomItem(RoomItem roomItem) {
		roomItems.Add(roomItem);
	}

	public static List<InventoryItem> GetInventoryItems() {
		return inventoryItems;
	}

	public static List<RoomItem> GetRoomItems(string roomId) {
		List<RoomItem> roomItems = new List<RoomItem>();

		foreach (RoomItem roomItem in ItemManager.roomItems)
			if (roomItem.GetRoomId().Equals(roomId))
				roomItems.Add(roomItem);
		
		return roomItems;
	}

}
