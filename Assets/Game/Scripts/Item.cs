using UnityEngine;

public class Item : InteractiveObject {

	// TODO
	private string roomId;

	public Vector2 GetPosition() {
		return transform.position;
	}

	public string GetRoomId() {
		return roomId;
	}

	public void SetPosition(Vector2 position) {
		transform.position = position;
	}

	public void SetRoomId(string roomId) {
		this.roomId = roomId;
	}

}
