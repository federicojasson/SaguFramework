namespace SaguFramework {
	
	public static class Game {

		public static void CloseMenu() {
			MenuHandler.GetInstance().CloseMenu();
		}

		public static void Exit() {
			// TODO
		}

		public static void HideInventory() {
			InventoryHandler.GetInstance().HideInventory();
		}

		public static void LoadGame(string stateId) {
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

		public static void OpenMenu(string menuId) {
			MenuHandler.GetInstance().OpenMenu(menuId);
		}

		public static void PauseGame() {
			MenuHandler.GetInstance().OpenPauseMenu();
		}

		public static void SaveGame(string stateId) {
			// TODO
		}

		public static void ShowInventory() {
			InventoryHandler.GetInstance().ShowInventory();
		}

	}
	
}
