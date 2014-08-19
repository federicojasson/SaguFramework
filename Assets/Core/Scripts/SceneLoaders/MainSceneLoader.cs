using System.Collections;

public class MainSceneLoader : SceneLoader {

	public override void OnUnloadScene() {
		// TODO
	}
	
	protected override IEnumerator LoadSceneCoroutine() {
		// TODO: load things

		OptionManager.LoadOptions();

		GameManager.LoadMainMenu();

		// TODO
		yield break;
	}

}
