using System.Collections;
using UnityEngine;

public static class GuiManager {

	public static SplashScreen CreateSplashScreen(string id) {
		return GuiAssets.CreateSplashScreen(id);
	}

	public static SplashScreen CreateSplashScreenFromGroup(string id) {
		return GuiAssets.CreateSplashScreenFromGroup(id);
	}
	
	public static IEnumerator FadeInCoroutine(float fadeSpeed, Texture2D fadeTexture) {
		return DisplayEffector.FadeInCoroutine(fadeSpeed, fadeTexture);
	}

	public static IEnumerator FadeOutCoroutine(float fadeSpeed, Texture2D fadeTexture) {
		return DisplayEffector.FadeOutCoroutine(fadeSpeed, fadeTexture);
	}

}
