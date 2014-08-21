using System.Collections;
using UnityEngine;

public static class GuiManager {

	public static void CloseCurrentMenu() {
		MenuManager.CloseCurrentMenu();
	}
	
	public static IEnumerator FadeInCoroutine(float fadeSpeed, Sprite fadeSprite) {
		return DisplayEffector.FadeInCoroutine(fadeSpeed, fadeSprite);
	}

	public static IEnumerator FadeOutCoroutine(float fadeSpeed, Sprite fadeSprite) {
		return DisplayEffector.FadeOutCoroutine(fadeSpeed, fadeSprite);
	}

	public static Menu OpenMenu(string id) {
		return MenuManager.OpenMenu(id);
	}
	
	public static SplashScreen ShowSplashScreen(string id) {
		return GuiAssets.CreateSplashScreen(id);
	}
	
	public static SplashScreen ShowSplashScreenFromGroup(string id) {
		return GuiAssets.CreateSplashScreenFromGroup(id);
	}

}
