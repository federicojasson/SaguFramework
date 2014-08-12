public static class ParameterModule {

	public const string SPLASH_SCREEN_SCENE = "SplashScreen";

	private static ParameterModuleBehaviour behaviour;
	
	public static void SetBehaviour(ParameterModuleBehaviour behaviour) {
		ParameterModule.behaviour = behaviour;
	}
	
}
