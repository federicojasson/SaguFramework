namespace SaguFramework {
	
	public static class Game {

		public static void CloseMenu() {
			MenuHandler.GetInstance().CloseMenu();
		}

		public static void Exit() {
			// TODO
		}

		public static void LoadGame() {
			// TODO
		}

		public static void NewGame() {
			State.LoadInitial();
			Objects.GetLoader().ChangeScene(Parameters.SceneRoom);
		}

		public static void NewGame(string splashScreenGroupId) {
			State.LoadInitial();
			SplashScreenHandler.GetInstance().SetCurrentGroupId(splashScreenGroupId);
			Objects.GetLoader().ChangeScene(Parameters.SceneSplashScreen);
		}

		public static void OpenMainMenu() {
			Objects.GetLoader().ChangeScene(Parameters.SceneMainMenu);
		}

		public static void OpenMenu(string id) {
			MenuHandler.GetInstance().OpenMenu(id);
		}

		public static void PauseGame() {
			MenuHandler.GetInstance().OpenPauseMenu();
		}

		public static void ResumeGame() {
			CloseMenu();
		}

		public static void SaveGame() {
			// TODO
		}

	}
	
}
