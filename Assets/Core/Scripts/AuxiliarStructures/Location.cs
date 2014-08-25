using UnityEngine;

public class Location {
	
	public Vector2 GamePosition;
	public string RoomId;

	public Location(Vector2 gamePosition, string roomId) {
		GamePosition = gamePosition;
		RoomId = roomId;
	}

}
