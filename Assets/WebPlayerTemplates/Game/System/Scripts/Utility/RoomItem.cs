using UnityEngine;

public class RoomItem {

	private string id;
	private Vector2 position;
	private string roomId;

	public RoomItem(string id, string roomId, Vector2 position) {
		this.id = id;
		this.roomId = roomId;
		this.position = position;
	}

	public string GetId() {
		return id;
	}

	public Vector2 GetPosition() {
		return position;
	}

	public string GetRoomId() {
		return roomId;
	}

}
