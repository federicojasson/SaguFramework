using System.Collections;
using UnityEngine;

public static class GuiManager {

	public static Texture2D FadeTexture;

	private static GuiManagerWorker worker;

	public static IEnumerator CurtainFadeInCoroutine(float fadeInSpeed) {
		return CurtainManager.FadeInCoroutine(fadeInSpeed);
	}

	public static IEnumerator CurtainFadeOutCoroutine(float fadeOutSpeed) {
		return CurtainManager.FadeOutCoroutine(fadeOutSpeed);
	}

	public static bool DrawButton(string text, Rect rectangle) {
		return DrawingManager.DrawButton(text, rectangle);
	}

	public static void SetWorker(GuiManagerWorker worker) {
		GuiManager.worker = worker;

		FadeTexture = worker.FadeTexture;
	}

	public static void ShowMenu(string id) {
		Menu menu = CreateMenu(id);
		menu.Show();
	}

	private static Menu CreateMenu(string id) {
		Menu menuModel = worker.MenuModels[id];
		return (Menu) Object.Instantiate(menuModel);
	}
	
}
