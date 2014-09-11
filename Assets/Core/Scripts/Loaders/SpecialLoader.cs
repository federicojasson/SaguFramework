using System.Collections;

namespace SaguFramework {
	
	public class SpecialLoader : Loader {

		protected override IEnumerator LoadSceneCoroutine() {
			yield return StartCoroutine(GraphicHandler.FadeIn(Parameters.GetSpecialLoaderParameters().FadeIn));
		}
		
		protected override IEnumerator UnloadSceneCoroutine() {
			yield return StartCoroutine(GraphicHandler.FadeOut(Parameters.GetSpecialLoaderParameters().FadeOut));
		}

	}
	
}
