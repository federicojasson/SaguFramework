using System.Collections;
using UnityEngine;

public class SplashScreenLoader : MonoBehaviour {
	
	public void Start() {
		StartCoroutine(LoadCoroutine());
	}
	
	private IEnumerator LoadCoroutine() {
		Timer timer = Factory.CreateTimer();
		timer.RegisterStartTime();

		yield return StartCoroutine(GUIManager.GetFadeInCoroutine());

		// TODO: load resources here

		float minDelay = Configurations.SPLASH_SCREEN_MIN_DELAY;
		yield return StartCoroutine(timer.WaitForAtLeastSecondsCoroutine(minDelay));

		yield return StartCoroutine(GUIManager.GetFadeOutCoroutine());

		// TODO: this is a test
		Application.LoadLevel(RoomManager.GetCurrentRoom());
	}
	
}
