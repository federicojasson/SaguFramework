using UnityEngine;

public class Location {

	public string RoomId;
	public Vector2 Position;

	public Location(string roomId, Vector2 position) {
		RoomId = roomId;
		Position = position;
	}

}
