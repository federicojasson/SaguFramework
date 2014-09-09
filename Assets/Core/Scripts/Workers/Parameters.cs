namespace SaguFramework {
	
	public class Parameters : Worker {

		public const string SceneMain = "Main";
		public const string SceneMainMenu = "MainMenu";
		public const string SceneRoom = "Room";
		public const string SceneSpecial = "Special";
		public const string SceneSplashScreen = "SplashScreen";

		public static float GetGameAspectRatio() {
			// TODO
			return 1;
		}

		public static float GetPixelsPerUnit() {
			// TODO
			return 1;
		}

		public GameParameters GameParameters;

	}
	
}
