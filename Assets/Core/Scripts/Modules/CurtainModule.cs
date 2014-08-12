using System.Collections;

public static class CurtainModule {
	
	private static CurtainModuleBehaviour behaviour;

	public static IEnumerator FadeInCoroutine(float fadeInSpeed) {
		return behaviour.FadeInCoroutine(fadeInSpeed);
	}
	
	public static IEnumerator FadeOutCoroutine(float fadeOutSpeed) {
		return behaviour.FadeOutCoroutine(fadeOutSpeed);
	}

	public static void SetBehaviour(CurtainModuleBehaviour behaviour) {
		CurtainModule.behaviour = behaviour;
	}
	
}
