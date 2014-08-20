public static class RoomManager {

	private static string currentRoomId;

	public static Room CreateRoom(string id) {
		return GameAssets.CreateRoom(id);
	}

	public static string GetCurrentRoomId() {
		return currentRoomId;
	}

	public static void Reset() {
		// TODO
	}

	public static void SetCurrentRoomId(string roomId) {
		currentRoomId = roomId;
	}

}
