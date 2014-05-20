using UnityEngine;

public static class RoomManager {

	private static string currentRoom;

	public static string GetCurrentRoom() {
		return currentRoom;
	}

	public static void LoadRoom(string room) {
		// Loads the room
		Application.LoadLevel(room);
		currentRoom = room;
	}
	
}
