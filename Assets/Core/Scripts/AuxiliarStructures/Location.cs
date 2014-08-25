using UnityEngine;

public class Location {
	
	public Vector2 PositionInGame;
	public string RoomId;

	public Location(Vector2 positionInGame, string roomId) {
		PositionInGame = positionInGame;
		RoomId = roomId;
	}

}
