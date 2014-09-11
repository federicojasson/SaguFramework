namespace SaguFramework {
	
	public static class Game {

		public static void CloseMenu() {
			// TODO
		}

		public static void Exit() {
			// TODO
		}

		public static void LoadGame(string stateId) {
			State.Load(stateId);
			Loader.ChangeScene(Parameters.SceneRoom);
		}

		public static void LoadGame(string stateId, string groupId) {
			State.Load(stateId);
			Loader.ChangeScene(Parameters.SceneSplashScreen);
		}

		public static void OpenMainMenu() {
			Loader.ChangeScene(Parameters.SceneMainMenu);
		}

		public static void NewGame() {
			State.LoadInitial();
			Loader.ChangeScene(Parameters.SceneRoom);
		}

		public static void NewGame(string groupId) {
			State.LoadInitial();
			SplashScreenHandler.SetCurrentGroupId(groupId);
			Loader.ChangeScene(Parameters.SceneSplashScreen);
		}

		public static void OpenMenu(string menuId) {
			// TODO
		}

		public static void SaveGame(string stateId) {


			// TODO: actualizar estado de las entidades
			State.Save(stateId);
		}

	}
	
}
