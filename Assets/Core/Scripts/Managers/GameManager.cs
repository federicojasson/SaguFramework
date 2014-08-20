using UnityEngine;

public static class GameManager {

	public static void ChangeRoom(string roomId) {
		RoomManager.SetCurrentRoomId(roomId);
		LoadRoom();
	}

	public static void Exit() {
		Application.Quit();
	}

	public static void LoadGame(string stateId) {
		StateManager.LoadState(stateId);
		LoadRoom();
	}

	public static void LoadMainMenu() {
		SceneManager.LoadScene(Parameters.MainMenuScene);
	}

	public static void NewGame() {
		StateManager.LoadInitialState();
		LoadRoom();
	}

	public static void SaveGame(string stateId) {
		StateManager.SaveState(stateId);
	}

	private static void LoadRoom() {
		if (Parameters.GetUseSplashScreens())
			SceneManager.LoadScene(Parameters.SplashScreenScene);
		else
			SceneManager.LoadScene(Parameters.RoomScene);
	}

}
