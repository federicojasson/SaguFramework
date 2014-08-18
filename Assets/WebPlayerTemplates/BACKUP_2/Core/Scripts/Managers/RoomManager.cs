using UnityEngine;

public static class RoomManager {

	private static string currentRoomId;
	private static RoomManagerWorker worker;

	public static void ClearState() {
		currentRoomId = null;
	}
	
	public static void CreateRoom(string id) {
		Room roomModel = worker.RoomModels[id];
		Room room = (Room) Object.Instantiate(roomModel);
		
		GameObject background = new GameObject("Background"); // TODO: use ConfigurationManager
		background.transform.parent = room.transform;
		SpriteRenderer spriteRenderer = background.AddComponent<SpriteRenderer>();
		spriteRenderer.sortingLayerName = ConfigurationManager.SortingLayerBackground;
		spriteRenderer.sortingOrder = 0; // TODO: use constant?
		spriteRenderer.sprite = room.Background;
	}

	public static string GetCurrentRoomId() {
		return currentRoomId;
	}

	public static void SetCurrentRoomId(string roomId) {
		currentRoomId = roomId;
	}

	public static void SetWorker(RoomManagerWorker worker) {
		RoomManager.worker = worker;
	}
	
}
