using System.Collections;

namespace SaguFramework {
	
	public sealed class SplashScreenLoader : Loader {
		
		protected override IEnumerator LoadSceneCoroutine() {
			SplashScreenManager.ShowSplashScreenFromCurrentGroup();
			yield return StartCoroutine(Drawer.FadeIn(Parameters.GetSplashScreenLoaderParameters().FadeIn));
			yield return StartCoroutine(SplashScreenManager.Delay());
			Loader.ChangeScene(Parameters.SceneRoom);
		}
		
		protected override IEnumerator UnloadSceneCoroutine() {
			yield return StartCoroutine(Drawer.FadeOut(Parameters.GetSplashScreenLoaderParameters().FadeOut));
		}

	}
	
}
