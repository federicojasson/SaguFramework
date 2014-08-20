using System.Collections;

public class SplashScreenSceneLoader : SceneLoader {

	public override void OnUnloadScene() {
		// TODO
	}
	
	protected override IEnumerator LoadSceneCoroutine() {
		SceneManager.LoadScene(Parameters.RoomScene);

		// TODO
		yield break;
	}

}
