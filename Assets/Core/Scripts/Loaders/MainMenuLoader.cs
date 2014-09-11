using System.Collections;

namespace SaguFramework {
	
	public class MainMenuLoader : Loader {
		
		protected override IEnumerator LoadSceneCoroutine() {
			MenuHandler.OpenMainMenu();
			yield return StartCoroutine(GraphicHandler.FadeIn(Parameters.GetMainMenuLoaderParameters().FadeIn));
		}
		
		protected override IEnumerator UnloadSceneCoroutine() {
			yield return StartCoroutine(GraphicHandler.FadeOut(Parameters.GetMainMenuLoaderParameters().FadeOut));
		}

	}
	
}
