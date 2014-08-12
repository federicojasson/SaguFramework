using System.Collections;
using UnityEngine;

public class SplashScreenLoader : MonoBehaviour {
	
	public void Start() {
		StartCoroutine(LoadCoroutine());
	}
	
	private IEnumerator LoadCoroutine() {
		Timer timer = FactoryModule.CreateTimer();
		timer.RegisterStartTime();

		IEnumerator fadeInCoroutine = CurtainModule.GetFadeInCoroutine(ConfigurationModule.splashScreenCurtainFadeInSpeed);
		yield return StartCoroutine(fadeInCoroutine);

		// TODO: load resources here

		float minimumDelayTime = ConfigurationModule.splashScreenMinimumDelayTime;
		yield return StartCoroutine(timer.WaitForAtLeastSecondsCoroutine(minimumDelayTime));

		IEnumerator fadeOutCoroutine = CurtainModule.GetFadeOutCoroutine(ConfigurationModule.splashScreenCurtainFadeOutSpeed);
		yield return StartCoroutine(fadeOutCoroutine);
		
		// Loads the current room
		RoomModule.LoadRoom(RoomModule.GetCurrentRoom());
	}
	
}
