using UnityEngine;

public static class GameManager {
	
	public static void ChangeRoom(bool useSplashScreen, string roomId, string entryPositionId) {
		RoomManager.SetCurrentEntryPositionId(entryPositionId);
		RoomManager.SetCurrentRoomId(roomId);
		LoadRoom(useSplashScreen);
	}
	
	public static Room CreateCurrentRoom() {
		string currentRoomId = RoomManager.GetCurrentRoomId();

		CharacterManager.CreateCharacters(currentRoomId);
		ItemManager.CreateItems(currentRoomId);
		Room room = RoomManager.CreateRoom(currentRoomId);
		
		return room;
	}

	public static void Exit() {
		Application.Quit();
	}

	public static void LoadGame(bool useSplashScreen, string stateId) {
		StateManager.LoadState(stateId);
		LoadRoom(useSplashScreen);
	}

	public static void LoadMainMenu() {
		SceneManager.LoadScene(Parameters.MainMenuScene);
	}

	public static void NewGame(bool useSplashScreen) {
		StateManager.LoadInitialState();
		LoadRoom(useSplashScreen);
	}

	public static void SaveGame(string stateId) {
		StateManager.SaveState(stateId);
	}

	private static void LoadRoom(bool useSplashScreen) {
		if (useSplashScreen)
			SceneManager.LoadScene(Parameters.SplashScreenScene);
		else
			SceneManager.LoadScene(Parameters.RoomScene);
	}

}
