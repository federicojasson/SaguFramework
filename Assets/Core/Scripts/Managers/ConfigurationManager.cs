public static class ConfigurationManager {

	public const string PlayerCharacterClass = "PlayerCharacter";
	public const string SplashScreenScene = "SplashScreen";
	public const string StateFileExtension = ".xml";
	public const string XmlAttributePlayerCharacter = "player-character";
	public const string XmlTagCharacter = "character";
	public const string XmlTagCurrentRoom = "current-room";
	public const string XmlTagId = "id";
	public const string XmlTagInventoryItem = "inventory-item";
	public const string XmlTagItem = "item";
	public const string XmlTagLocation = "location";
	public const string XmlTagPosition = "position";
	public const string XmlTagRoom = "room";
	public const string XmlTagX = "x";
	public const string XmlTagY = "y";

	public static string MainMenuId;
	public static string MainMenuScene;
	public static float MainSplashScreenCurtainFadeInSpeed;
	public static float MainSplashScreenCurtainFadeOutSpeed;
	public static float MainSplashScreenMinimumDelayTime;
	public static float RoomCurtainFadeInSpeed;
	public static float RoomCurtainFadeOutSpeed;
	public static float RoomMinimumDelayTime;
	public static float SplashScreenCurtainFadeInSpeed;
	public static float SplashScreenCurtainFadeOutSpeed;
	public static float SplashScreenMinimumDelayTime;
	public static string StateFilesDirectoryPath;
	public static bool UseSplashScreens;

	public static void SetWorker(ConfigurationManagerWorker worker) {
		MainMenuId = worker.MainMenuId;
		MainMenuScene = worker.MainMenuScene;
		MainSplashScreenCurtainFadeInSpeed = worker.MainSplashScreenCurtainFadeInSpeed;
		MainSplashScreenCurtainFadeOutSpeed = worker.MainSplashScreenCurtainFadeOutSpeed;
		MainSplashScreenMinimumDelayTime = worker.MainSplashScreenMinimumDelayTime;
		RoomCurtainFadeInSpeed = worker.RoomCurtainFadeInSpeed;
		RoomCurtainFadeOutSpeed = worker.RoomCurtainFadeOutSpeed;
		RoomMinimumDelayTime = worker.RoomMinimumDelayTime;
		SplashScreenCurtainFadeInSpeed = worker.SplashScreenCurtainFadeInSpeed;
		SplashScreenCurtainFadeOutSpeed = worker.SplashScreenCurtainFadeOutSpeed;
		SplashScreenMinimumDelayTime = worker.SplashScreenMinimumDelayTime;
		StateFilesDirectoryPath = worker.StateFilesDirectoryPath;
		UseSplashScreens = worker.UseSplashScreens;
	}

}
