using System.Collections;

namespace SaguFramework {
	
	public class MainLoader : Loader {

		private static void LoadOptions() {
			Options.Load();
			//Game.ApplyOptions(); TODO
		}

		protected override IEnumerator LoadSceneCoroutine() {
			// TODO: debug
			//Game.NewGame();
			//Game.OpenMainMenu();

			LoadOptions();
			SoundPlayer.StopAllSounds();
			SoundPlayer.PlayMainEffect();
			SplashScreenHandler.ShowMainSplashScreen();
			yield return StartCoroutine(GraphicHandler.FadeIn(Parameters.GetMainLoaderParameters().FadeIn));
			yield return StartCoroutine(SplashScreenHandler.Delay());
			Loader.ChangeScene(Parameters.SceneMainMenu);
		}
		
		protected override IEnumerator UnloadSceneCoroutine() {
			yield return StartCoroutine(GraphicHandler.FadeOut(Parameters.GetMainLoaderParameters().FadeOut));
		}

	}
	
}
