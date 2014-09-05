using System.Collections;

namespace SaguFramework {
	
	public class SplashScreenLoader : Loader {
		
		protected override IEnumerator LoadSceneCoroutine() {
			SplashScreenHandler.GetInstance().ShowSplashScreenFromCurrentGroup();
			yield return StartCoroutine(FadeInCoroutine(Parameters.GetSplashScreenLoaderParameters().FadeIn));
			yield return StartCoroutine(Objects.GetSplashScreen().Delay());
			ChangeScene(Parameters.SceneRoom);
		}
		
		protected override IEnumerator UnloadSceneCoroutine() {
			yield return StartCoroutine(FadeOutCoroutine(Parameters.GetSplashScreenLoaderParameters().FadeOut));
		}

	}
	
}
