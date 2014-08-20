using System.Collections;

public class SplashScreenSceneLoader : SceneLoader {

	public override void OnUnloadScene() {
		// TODO
	}
	
	protected override IEnumerator LoadSceneCoroutine() {

		SplashScreen splashScreen = GuiManager.ShowSplashScreenFromGroup(Parameters.RoomSplashScreenGroup);
		//splashScreen.FadeParameters; // TODO

		SceneManager.LoadScene(Parameters.RoomScene);

		// TODO
		yield break;
	}

}
