using System.Collections;
using UnityEngine;

public class MainSplashScreenLoader : MonoBehaviour {
	
	public void Start() {
		StartCoroutine(LoadCoroutine());
	}

	private IEnumerator LoadCoroutine() {
		Timer timer = HelperModule.CreateTimer();
		timer.RegisterStartTime();

		IEnumerator fadeInCoroutine = CurtainModule.FadeInCoroutine(Configuration.MainSplashScreenCurtainFadeInSpeed);
		yield return StartCoroutine(fadeInCoroutine);

		string initialRoom;
		if (Configuration.GameHasMainMenu)
			// The main menu room is the initial one
			initialRoom = Configuration.MainMenuRoom;
		else {
			// TODO: load game state
			initialRoom = "some room";
		}

		// TODO: load resources here

		float minimumDelayTime = Configuration.MainSplashScreenMinimumDelayTime;
		yield return StartCoroutine(timer.WaitForAtLeastSecondsCoroutine(minimumDelayTime));

		IEnumerator fadeOutCoroutine = CurtainModule.FadeOutCoroutine(Configuration.MainSplashScreenCurtainFadeOutSpeed);
		yield return StartCoroutine(fadeOutCoroutine);

		// Loads the initial room
		RoomModule.LoadRoom(initialRoom);
	}
	
}
