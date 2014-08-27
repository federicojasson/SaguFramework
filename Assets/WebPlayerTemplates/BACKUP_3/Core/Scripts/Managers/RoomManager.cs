namespace FrameworkNamespace {

	public static class RoomManager {

		private static string currentEntryPositionId;
		private static Room currentRoom;
		private static string currentRoomId;

		public static void CreateCurrentRoom() {
			currentRoom = GameAssets.CreateRoom(currentRoomId);

			CharacterManager.CreateCharacters(currentRoomId, currentRoom.ScaleFactor);
			ItemManager.CreateItems(currentRoomId, currentRoom.ScaleFactor);
		}

		public static Room GetCurrentRoom() {
			return currentRoom;
		}

		public static void SetCurrentEntryPositionId(string entryPositionId) {
			currentEntryPositionId = entryPositionId;
		}

		public static void SetCurrentRoomId(string roomId) {
			currentRoomId = roomId;
		}

	}

}
