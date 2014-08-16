using System.Collections;
using UnityEngine;

public class MainLoader : MonoBehaviour {
	
	public void Start() {
		StartCoroutine(LoadCoroutine());
	}

	private IEnumerator LoadCoroutine() {
		SplashScreenManager.CreateMainSplashScreen();

		Timer timer = UtilityManager.CreateTimer();
		timer.RegisterStartTime();

		float fadeInSpeed = ConfigurationManager.MainSplashScreenCurtainFadeInSpeed;
		yield return StartCoroutine(CurtainManager.FadeInCoroutine(fadeInSpeed));

		// TODO: load options

		float minimumDelayTime = ConfigurationManager.MainSplashScreenMinimumDelayTime;
		yield return StartCoroutine(timer.WaitForAtLeastSecondsCoroutine(minimumDelayTime));

		float fadeOutSpeed = ConfigurationManager.MainSplashScreenCurtainFadeOutSpeed;
		yield return StartCoroutine(CurtainManager.FadeOutCoroutine(fadeOutSpeed));

		StateManager.LoadMainMenu();
	}
	
}
