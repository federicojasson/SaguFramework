using System.Collections;
using UnityEngine;

public static class GuiManager {

	public static void CloseCurrentMenu() {
		MenuManager.CloseCurrentMenu();
	}

	public static IEnumerator FadeInCoroutine(float speed, Texture2D texture) {
		return Fader.FadeInCoroutine(speed, texture);
	}

	public static IEnumerator FadeOutCoroutine(float speed, Texture2D texture) {
		return Fader.FadeOutCoroutine(speed, texture);
	}

	public static Texture2D GetDefaultFadeTexture() {
		return GuiAssets.GetDefaultFadeTexture();
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
