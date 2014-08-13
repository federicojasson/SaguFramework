public static class Configuration {

	public static bool GameHasMainMenu;
	public static string MainMenuRoom;
	public static float MainSplashScreenCurtainFadeInSpeed;
	public static float MainSplashScreenCurtainFadeOutSpeed;
	public static float MainSplashScreenMinimumDelayTime;
	public static float RoomCurtainFadeInSpeed;
	public static float RoomCurtainFadeOutSpeed;
	public static float RoomMinimumDelayTime;
	public static float SplashScreenCurtainFadeInSpeed;
	public static float SplashScreenCurtainFadeOutSpeed;
	public static float SplashScreenMinimumDelayTime;

	private static ConfigurationBehaviour behaviour;
	
	public static void SetBehaviour(ConfigurationBehaviour behaviour) {
		Configuration.behaviour = behaviour;

		GameHasMainMenu = behaviour.GameHasMainMenu;
		MainMenuRoom = behaviour.MainMenuRoom;
		MainSplashScreenCurtainFadeInSpeed = behaviour.MainSplashScreenCurtainFadeInSpeed;
		MainSplashScreenCurtainFadeOutSpeed = behaviour.MainSplashScreenCurtainFadeOutSpeed;
		MainSplashScreenMinimumDelayTime = behaviour.MainSplashScreenMinimumDelayTime;
		RoomCurtainFadeInSpeed = behaviour.RoomCurtainFadeInSpeed;
		RoomCurtainFadeOutSpeed = behaviour.RoomCurtainFadeOutSpeed;
		RoomMinimumDelayTime = behaviour.RoomMinimumDelayTime;
		SplashScreenCurtainFadeInSpeed = behaviour.SplashScreenCurtainFadeInSpeed;
		SplashScreenCurtainFadeOutSpeed = behaviour.SplashScreenCurtainFadeOutSpeed;
		SplashScreenMinimumDelayTime = behaviour.SplashScreenMinimumDelayTime;
	}

}
