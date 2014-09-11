using System.Collections;

namespace SaguFramework {
	
	public class SplashScreenLoader : Loader {
		
		protected override IEnumerator LoadSceneCoroutine() {
			SplashScreenHandler.ShowSplashScreenFromCurrentGroup();
			yield return StartCoroutine(GraphicHandler.FadeIn(Parameters.GetSplashScreenLoaderParameters().FadeIn));
			yield return StartCoroutine(SplashScreenHandler.Delay());
			Loader.ChangeScene(Parameters.SceneRoom);
		}
		
		protected override IEnumerator UnloadSceneCoroutine() {
			yield return StartCoroutine(GraphicHandler.FadeOut(Parameters.GetSplashScreenLoaderParameters().FadeOut));
		}

	}
	
}
