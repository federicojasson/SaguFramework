using UnityEngine;

public class Location {
	
	public Vector2 Position;
	public string RoomId;

	public Location(Vector2 position, string roomId) {
		Position = position;
		RoomId = roomId;
	}

}
