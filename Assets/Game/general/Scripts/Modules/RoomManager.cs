using UnityEngine;

// TODO: maybe unnecessary: currentRoomId can be obtained by Application.loadedLevelName;
// and LoadRoom is just Application.LoadLevel(roomId);
public static class RoomManager {

	private static string currentRoomId;

	public static string GetCurrentRoomId() {
		return currentRoomId;
	}

	public static void LoadRoom(string roomId) {
		currentRoomId = roomId;

		// Loads the scene
		Application.LoadLevel(roomId);
	}

}
