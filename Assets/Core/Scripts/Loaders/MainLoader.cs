using System.Collections;

namespace SaguFramework {
	
	public class MainLoader : Loader {

		private static void LoadOptions() {
			// TODO
		}

		protected override IEnumerator LoadSceneCoroutine() {
			// TODO: debug
			Game.NewGame();

			LoadOptions();
			// TODO: play main effect
			SplashScreenHandler.ShowMainSplashScreen();
			yield return StartCoroutine(GraphicHandler.FadeIn(Parameters.GetMainLoaderParameters().FadeIn));
			yield return StartCoroutine(SplashScreenHandler.Delay());
			Game.OpenMainMenu();
		}
		
		protected override IEnumerator UnloadSceneCoroutine() {
			yield return StartCoroutine(GraphicHandler.FadeOut(Parameters.GetMainLoaderParameters().FadeOut));
		}

	}
	
}
