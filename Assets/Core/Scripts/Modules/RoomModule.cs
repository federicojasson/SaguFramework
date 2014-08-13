using UnityEngine;

public static class RoomModule {
	
	private static RoomModuleBehaviour behaviour;
	private static string currentRoom;

	public static string GetCurrentRoom() {
		return currentRoom;
	}

	public static void LoadRoom(string room) {
		currentRoom = room;
		Application.LoadLevel(room);
	}

	public static void LoadRoomWithSplashScreen(string room) {
		currentRoom = room;
		Application.LoadLevel(ParameterModule.SplashScreenScene);
	}

	public static void SetBehaviour(RoomModuleBehaviour behaviour) {
		RoomModule.behaviour = behaviour;
	}
	
}
