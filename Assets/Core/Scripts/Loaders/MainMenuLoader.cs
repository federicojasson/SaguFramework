using System.Collections;
using UnityEngine;

public class MainMenuLoader : MonoBehaviour {
	
	public void Start() {
		StartCoroutine(LoadCoroutine());
	}
	
	private IEnumerator LoadCoroutine() {
		GuiManager.ShowMenu(ConfigurationManager.MainMenuId);

		float fadeInSpeed = ConfigurationManager.SplashScreenCurtainFadeInSpeed;
		yield return StartCoroutine(GuiManager.CurtainFadeInCoroutine(fadeInSpeed));
	}
	
}
