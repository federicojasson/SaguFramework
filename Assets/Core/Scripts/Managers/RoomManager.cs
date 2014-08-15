using UnityEngine;

public static class RoomManager {

	private static string currentRoom;

	public static void ClearState() {
		currentRoom = null;
	}

	public static string GetCurrentRoom() {
		return currentRoom;
	}

	public static void SetCurrentRoom(string room) {
		currentRoom = room;
	}
	
}
