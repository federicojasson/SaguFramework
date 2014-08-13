using System.Collections;
using UnityEngine;

public static class GuiManager {

	public static Texture2D FadeTexture;

	public static IEnumerator CurtainFadeInCoroutine(float fadeInSpeed) {
		return CurtainManager.FadeInCoroutine(fadeInSpeed);
	}

	public static IEnumerator CurtainFadeOutCoroutine(float fadeOutSpeed) {
		return CurtainManager.FadeOutCoroutine(fadeOutSpeed);
	}

	public static void SetWorker(GuiManagerWorker worker) {
		FadeTexture = worker.FadeTexture;
	}
	
}
