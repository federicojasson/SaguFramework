using System.Collections;

public class MainMenuSceneLoader : SceneLoader {
	
	public override void OnUnloadScene() {
		// TODO
	}
	
	protected override IEnumerator LoadSceneCoroutine() {
		GuiManager.OpenMenu(Parameters.GetMainMenuId());

		// TODO: fade in

		// TODO
		yield break;
	}

}
