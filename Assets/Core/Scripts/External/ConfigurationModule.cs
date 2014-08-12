public static class ConfigurationModule {

	public static bool gameHasMainMenu;
	public static string mainMenuRoom;
	public static float mainSplashScreenCurtainFadeInSpeed;
	public static float mainSplashScreenCurtainFadeOutSpeed;
	public static float mainSplashScreenMinimumDelayTime;
	public static float roomCurtainFadeInSpeed;
	public static float roomCurtainFadeOutSpeed;
	public static float roomMinimumDelayTime;
	public static float splashScreenCurtainFadeInSpeed;
	public static float splashScreenCurtainFadeOutSpeed;
	public static float splashScreenMinimumDelayTime;

	private static ConfigurationModuleBehaviour behaviour;
	
	public static void SetBehaviour(ConfigurationModuleBehaviour behaviour) {
		ConfigurationModule.behaviour = behaviour;

		// Initializes the configurations
		InitializeConfigurations();
	}

	private static void InitializeConfigurations() {
		gameHasMainMenu = behaviour.gameHasMainMenu;
		mainMenuRoom = behaviour.mainMenuRoom;
		mainSplashScreenCurtainFadeInSpeed = behaviour.mainSplashScreenCurtainFadeInSpeed;
		mainSplashScreenCurtainFadeOutSpeed = behaviour.mainSplashScreenCurtainFadeOutSpeed;
		mainSplashScreenMinimumDelayTime = behaviour.mainSplashScreenMinimumDelayTime;
		roomCurtainFadeInSpeed = behaviour.roomCurtainFadeInSpeed;
		roomCurtainFadeOutSpeed = behaviour.roomCurtainFadeOutSpeed;
		roomMinimumDelayTime = behaviour.roomMinimumDelayTime;
		splashScreenCurtainFadeInSpeed = behaviour.splashScreenCurtainFadeInSpeed;
		splashScreenCurtainFadeOutSpeed = behaviour.splashScreenCurtainFadeOutSpeed;
		splashScreenMinimumDelayTime = behaviour.splashScreenMinimumDelayTime;
	}

}
