using System.Collections;
using UnityEngine;

public class SplashScreenLoader : MonoBehaviour {
	
	public void Start() {
		StartCoroutine(LoadCoroutine());
	}

	private IEnumerator LoadCoroutine() {
		Timer timer = HelperModule.CreateTimer();
		timer.RegisterStartTime();

		IEnumerator fadeInCoroutine = CurtainModule.FadeInCoroutine(Configuration.SplashScreenCurtainFadeInSpeed);
		yield return StartCoroutine(fadeInCoroutine);

		// TODO: load resources here

		float minimumDelayTime = Configuration.SplashScreenMinimumDelayTime;
		yield return StartCoroutine(timer.WaitForAtLeastSecondsCoroutine(minimumDelayTime));

		IEnumerator fadeOutCoroutine = CurtainModule.FadeOutCoroutine(Configuration.SplashScreenCurtainFadeOutSpeed);
		yield return StartCoroutine(fadeOutCoroutine);
		
		// Loads the current room
		RoomModule.LoadRoom(RoomModule.GetCurrentRoom());
	}
	
}
