using System.Collections;
using UnityEngine;

public class MainSplashScreenLoader : MonoBehaviour {
	
	public void Start() {
		StartCoroutine(LoadCoroutine());
	}

	private IEnumerator LoadCoroutine() {
		Timer timer = FactoryModule.CreateTimer();
		timer.RegisterStartTime();

		IEnumerator fadeInCoroutine = CurtainModule.GetFadeInCoroutine(ConfigurationModule.mainSplashScreenCurtainFadeInSpeed);
		yield return StartCoroutine(fadeInCoroutine);

		string initialRoom;
		if (ConfigurationModule.gameHasMainMenu)
			// The main menu room is the initial one
			initialRoom = ConfigurationModule.mainMenuRoom;
		else {
			// TODO: load game state
			initialRoom = "some room";
		}

		// TODO: load resources here

		float minimumDelayTime = ConfigurationModule.mainSplashScreenMinimumDelayTime;
		yield return StartCoroutine(timer.WaitForAtLeastSecondsCoroutine(minimumDelayTime));

		IEnumerator fadeOutCoroutine = CurtainModule.GetFadeOutCoroutine(ConfigurationModule.mainSplashScreenCurtainFadeOutSpeed);
		yield return StartCoroutine(fadeOutCoroutine);

		// Loads the initial room
		RoomModule.LoadRoom(initialRoom);
	}
	
}
