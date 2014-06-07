using System.Collections;

public static class CurtainManager {
	
	private static CurtainManagerBehaviour behaviour;

	public static IEnumerator GetFadeInCoroutine() {
		return behaviour.FadeInCoroutine();
	}
	
	public static IEnumerator GetFadeOutCoroutine() {
		return behaviour.FadeOutCoroutine();
	}

	public static void SetBehaviour(CurtainManagerBehaviour behaviour) {
		CurtainManager.behaviour = behaviour;
	}
	
}
