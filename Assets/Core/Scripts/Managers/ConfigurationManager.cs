public static class ConfigurationManager {

	public const string SplashScreenScene = "SplashScreen";
	public const string XmlTagCharacter = "character";
	public const string XmlTagCurrentRoom = "current-room";
	public const string XmlTagInventoryItem = "inventory-item";
	public const string XmlTagItem = "item";

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
	public static bool UseSplashScreens;

	public static void SetWorker(ConfigurationManagerWorker worker) {
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
		UseSplashScreens = worker.UseSplashScreens;
	}

}
