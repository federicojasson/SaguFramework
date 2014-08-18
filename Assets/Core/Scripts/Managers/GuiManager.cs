using System.Collections;
using UnityEngine;

public static class GuiManager {

	public static SplashScreen CreateMainSplashScreen() {
		return GuiAssets.CreateMainSplashScreen();
	}

	public static SplashScreen CreateRandomRoomSplashScreen() {
		return GuiAssets.CreateRandomRoomSplashScreen();
	}

	public static IEnumerator FadeInCoroutine(float fadeSpeed) {
		// Gets the default fade in texture
		Texture2D fadeTexture = GuiAssets.GetDefaultFadeInTexture();

		return DisplayEffector.FadeInCoroutine(fadeSpeed, fadeTexture);
	}
	
	public static IEnumerator FadeInCoroutine(float fadeSpeed, Texture2D fadeTexture) {
		return DisplayEffector.FadeInCoroutine(fadeSpeed, fadeTexture);
	}

	public static IEnumerator FadeOutCoroutine(float fadeSpeed) {
		// Gets the default fade out texture
		Texture2D fadeTexture = GuiAssets.GetDefaultFadeOutTexture();

		return DisplayEffector.FadeOutCoroutine(fadeSpeed, fadeTexture);
	}

	public static IEnumerator FadeOutCoroutine(float fadeSpeed, Texture2D fadeTexture) {
		return DisplayEffector.FadeOutCoroutine(fadeSpeed, fadeTexture);
	}

}
