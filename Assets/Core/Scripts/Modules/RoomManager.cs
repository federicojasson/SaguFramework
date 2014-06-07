using UnityEngine;

public static class RoomManager {
	
	private static RoomManagerBehaviour behaviour;
	private static string currentRoom;

	public static string GetCurrentRoom() {
		return currentRoom;
	}

	public static void LoadRoom(string room) {
		currentRoom = room;
		Application.LoadLevel("SplashScreen"); // TODO: use a constant
	}

	public static void SetBehaviour(RoomManagerBehaviour behaviour) {
		RoomManager.behaviour = behaviour;
	}
	
}
