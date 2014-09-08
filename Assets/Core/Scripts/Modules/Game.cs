namespace SaguFramework {
	
	public static class Game {

		public static void ClearTooltip() {
			ScreenHandler.GetInstance().ClearTooltip();
		}

		public static void CloseMenu() {
			MenuHandler.GetInstance().CloseMenu();
			InputHandler.GetInstance().UpdateInputMode();
		}

		public static void Exit() {
			// TODO
		}

		public static void HideInventory() {
			ClearTooltip();
			InventoryHandler.GetInstance().HideInventory();
			InputHandler.GetInstance().UpdateInputMode();
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
			ClearTooltip();
			Objects.GetLoader().ChangeScene(Parameters.SceneMainMenu);
			InputHandler.GetInstance().UpdateInputMode();
		}

		public static void OpenMenu(string menuId) {
			MenuHandler.GetInstance().OpenMenu(menuId);
			InputHandler.GetInstance().UpdateInputMode();
		}

		public static void PauseGame() {
			ClearTooltip();
			MenuHandler.GetInstance().OpenPauseMenu();
			InputHandler.GetInstance().UpdateInputMode();
		}

		public static void SaveGame(string stateId) {
			// TODO
		}

		public static void SetTooltip(string tooltip) {
			ScreenHandler.GetInstance().SetTooltip(tooltip);
		}

		public static void ShowInventory() {
			ClearTooltip();
			InventoryHandler.GetInstance().ShowInventory();
			InputHandler.GetInstance().UpdateInputMode();
		}

	}
	
}
