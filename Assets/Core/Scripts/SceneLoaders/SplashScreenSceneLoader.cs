using System.Collections;

public class SplashScreenSceneLoader : SceneLoader {

	public override void OnUnloadScene() {
		// TODO
	}
	
	protected override IEnumerator LoadSceneCoroutine() {
		SplashScreen splashScreen = GuiManager.ShowSplashScreenFromGroup(Parameters.RoomSplashScreenGroupId);
		//splashScreen.FadeParameters; // TODO

		Timer timer = UtilityManager.CreateTimer();
		timer.RegisterStartTime();

		// TODO: fade in

		float minimumDelayTime = 2; // TODO: get somehow
		yield return StartCoroutine(timer.WaitForAtLeastSecondsCoroutine(minimumDelayTime));

		// TODO: fade out

		SceneManager.LoadScene(Parameters.RoomScene);
	}

}
