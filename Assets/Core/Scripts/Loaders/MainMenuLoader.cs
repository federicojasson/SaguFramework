using System.Collections;
using UnityEngine;

public class MainMenuLoader : MonoBehaviour {
	
	public void Start() {
		StartCoroutine(LoadCoroutine());
	}
	
	private IEnumerator LoadCoroutine() {
		MenuManager.OpenMenu(ConfigurationManager.MainMenuId);

		float fadeInSpeed = ConfigurationManager.SplashScreenCurtainFadeInSpeed;
		yield return StartCoroutine(CurtainManager.FadeInCoroutine(fadeInSpeed));
	}
	
}
