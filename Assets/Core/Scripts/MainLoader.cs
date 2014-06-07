using System.Collections;
using UnityEngine;

public class MainLoader : MonoBehaviour {
	
	public void Start() {
		StartCoroutine(LoadCoroutine());
	}

	private IEnumerator LoadCoroutine() {
		Timer timer = Factory.CreateTimer();
		timer.RegisterStartTime();

		yield return StartCoroutine(GUIManager.GetFadeInCoroutine());

		// TODO: load resources here

		float minDelay = Configurations.MAIN_SPLASH_SCREEN_MIN_DELAY;
		yield return StartCoroutine(timer.WaitForAtLeastSecondsCoroutine(minDelay));

		yield return StartCoroutine(GUIManager.GetFadeOutCoroutine());

		// TODO: this is a test
		RoomManager.LoadRoom("otro nivel");
	}
	
}
