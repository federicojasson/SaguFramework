public static class ParameterModule {

	public const string SplashScreenScene = "SplashScreen";

	private static ParameterModuleBehaviour behaviour;
	
	public static void SetBehaviour(ParameterModuleBehaviour behaviour) {
		ParameterModule.behaviour = behaviour;
	}
	
}
