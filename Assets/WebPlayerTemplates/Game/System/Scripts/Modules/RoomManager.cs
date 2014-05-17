using UnityEngine;

public static class RoomManager {

	public static string GetCurrentRoomId() {
		return Application.loadedLevelName;
	}

	public static void LoadRoom(string roomId) {
		Application.LoadLevel(roomId);
	}

}
