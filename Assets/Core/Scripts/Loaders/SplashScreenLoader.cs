using System.Collections;

namespace SaguFramework {
	
	public class SplashScreenLoader : Loader {
		
		protected override IEnumerator LoadSceneCoroutine() {
			yield return StartCoroutine(GraphicHandler.FadeIn(Parameters.GetSplashScreenLoaderParameters().FadeIn));
		}
		
		protected override IEnumerator UnloadSceneCoroutine() {
			yield return StartCoroutine(GraphicHandler.FadeOut(Parameters.GetSplashScreenLoaderParameters().FadeOut));
		}

	}
	
}
