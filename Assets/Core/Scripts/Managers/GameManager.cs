using UnityEngine;

public static class GameManager {

	public static void Exit() {
		Application.Quit();
	}

	public static void LoadMainMenu() {
		SceneManager.LoadScene(Parameters.MainMenuScene);
	}

	public static void NewGame() {
		StateManager.LoadInitialState();

		// TODO: change scene
	}

	/*public static void LoadMainMenu() {
		LoadScene(Parameters.SceneMainMenu);
	}

	public static void LoadRoom() {
		LoadScene(Parameters.SceneRoom);
	}

	public static void LoadRoomWithSplashScreen(string roomId) {
		// Sets the current room
		RoomManager.SetCurrentRoomId(roomId);
		
		GameManager.LoadSplashScreen();
	}
	
	public static void LoadRoomWithoutSplashScreen(string roomId) {
		// Sets the current room
		RoomManager.SetCurrentRoomId(roomId);
		
		GameManager.LoadRoom();
	}

	public static void LoadSplashScreen() {
		LoadScene(Parameters.SceneSplashScreen);
	}*/

}
