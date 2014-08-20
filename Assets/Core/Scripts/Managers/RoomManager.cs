public static class RoomManager {

	private static string currentEntryPositionId;
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

	public static void SetCurrentEntryPositionId(string entryPositionId) {
		currentEntryPositionId = entryPositionId;
	}

	public static void SetCurrentRoomId(string roomId) {
		currentRoomId = roomId;
	}

}
