namespace FrameworkNamespace {

	public static partial class GuiManager {

		private static SplashScreen currentSplashScreen;

		public static SplashScreen GetCurrentSplashScreen() {
			return currentSplashScreen;
		}

		public static void ShowGameSplashScreen() {
			ShowSplashScreen(Parameters.GameSplashScreenId);
		}

		public static void ShowRoomSplashScreen() {
			ShowSplashScreenFromGroup(Parameters.RoomSplashScreenGroupId);
		}

		public static void ShowSplashScreen(string id) {
			currentSplashScreen = GuiAssets.CreateSplashScreen(id);
		}
		
		public static void ShowSplashScreenFromGroup(string id) {
			currentSplashScreen = GuiAssets.CreateSplashScreenFromGroup(id);
		}

	}

}
