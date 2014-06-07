using System.Collections;

public static class GUIManager {
	
	private static GUIManagerBehaviour behaviour;

	public static IEnumerator GetFadeInCoroutine() {
		return CurtainManager.GetFadeInCoroutine();
	}

	public static IEnumerator GetFadeOutCoroutine() {
		return CurtainManager.GetFadeOutCoroutine();
	}

	public static void SetBehaviour(GUIManagerBehaviour behaviour) {
		GUIManager.behaviour = behaviour;
	}
	
}
