namespace SaguFramework {
	
	public static class Game {

		public static void Exit() {
			// TODO
		}

		public static void LoadGame() {
			// TODO
		}

		public static void NewGame(bool useSplashScreen) {
			State.LoadInitial();

			Loader loader = Objects.GetLoader();
			if (useSplashScreen)
				loader.ChangeScene(Parameters.SceneSplashScreen);
			else
				loader.ChangeScene(Parameters.SceneRoom);
		}

		public static void OpenMainMenu() {
			Objects.GetLoader().ChangeScene(Parameters.SceneMainMenu);
		}

		public static void PauseGame() {
			// TODO
		}

		public static void SaveGame() {
			// TODO
		}

	}
	
}
