using UnityEngine;

namespace FrameworkNamespace {

	public static class GameManager {
		
		public static void ChangeRoom(string roomId, string entryPositionId, bool useSplashScreen) {
			RoomManager.SetCurrentRoomId(roomId);
			RoomManager.SetCurrentEntryPositionId(entryPositionId);
			LoadRoom(useSplashScreen);
		}

		public static void Exit() {
			Application.Quit();
		}

		public static void LoadGame(string stateId, bool useSplashScreen) {
			StateManager.LoadState(stateId);
			LoadRoom(useSplashScreen);
		}

		public static void LoadGameMainMenu() {
			LoadMainMenu(Parameters.GameMainMenuId);
		}

		public static void LoadMainMenu(string mainMenuId) {
			GuiManager.SetCurrentMainMenuId(mainMenuId);
			SceneManager.LoadScene(Parameters.MainMenuScene);
		}
		
		public static void LoadRoom(bool useSplashScreen) {
			if (useSplashScreen)
				SceneManager.LoadScene(Parameters.SplashScreenScene);
			else
				SceneManager.LoadScene(Parameters.RoomScene);
		}

		public static void NewGame(bool useSplashScreen) {
			StateManager.LoadInitialState();
			LoadRoom(useSplashScreen);
		}

		public static void SaveGame(string stateId) {
			StateManager.SaveState(stateId);
		}

	}

}
