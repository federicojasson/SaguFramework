using System.Collections;
using UnityEngine;

public static class GuiManager {

	public static void CloseCurrentMenu() {
		MenuManager.CloseCurrentMenu();
	}

	public static IEnumerator FadeInCoroutine(float speed, Sprite sprite) {
		return DisplayEffector.FadeInCoroutine(speed, sprite);
	}

	public static IEnumerator FadeOutCoroutine(float speed, Sprite sprite) {
		return DisplayEffector.FadeOutCoroutine(speed, sprite);
	}

	public static Sprite GetDefaultFadeSprite() {
		return GuiAssets.GetDefaultFadeSprite();
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
