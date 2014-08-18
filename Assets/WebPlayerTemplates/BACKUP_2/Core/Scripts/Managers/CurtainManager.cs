using System.Collections;

public static class CurtainManager {
	
	private static CurtainManagerWorker worker;

	public static IEnumerator FadeInCoroutine(float fadeInSpeed) {
		return worker.FadeInCoroutine(fadeInSpeed);
	}
	
	public static IEnumerator FadeOutCoroutine(float fadeOutSpeed) {
		return worker.FadeOutCoroutine(fadeOutSpeed);
	}

	public static void SetWorker(CurtainManagerWorker worker) {
		CurtainManager.worker = worker;
	}
	
}
