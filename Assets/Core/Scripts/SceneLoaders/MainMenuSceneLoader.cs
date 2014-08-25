using System.Collections;

public class MainMenuSceneLoader : SceneLoader {
	
	public override void OnUnloadScene() {
		// TODO
	}
	
	protected override IEnumerator LoadSceneCoroutine() {
		Menu menu = GuiManager.OpenMenu(Parameters.MainMenuId);

		// TODO: manager?
		GameCamera.SetTarget(menu.transform);

		FadeParameters fadeInParameters = menu.FadeInParameters;
		if (! fadeInParameters.Ignore)
			yield return StartCoroutine(GuiManager.FadeInCoroutine(fadeInParameters.Speed, fadeInParameters.Texture));

		// TODO
		yield break;
	}

}
