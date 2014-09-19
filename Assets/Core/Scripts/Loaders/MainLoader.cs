using System.Collections;

namespace SaguFramework {
	
	public sealed class MainLoader : Loader {

		private static void LoadAndApplyOptions() {
			Options.Load();
			//Game.ApplyOptions(); TODO
		}

		protected override IEnumerator LoadSceneCoroutine() {
			// TODO: debug
			Framework.NewGame();
			//Game.OpenMainMenu();

			LoadAndApplyOptions();
			SoundPlayer.StopAllSounds();
			SoundPlayer.PlayMainEffect();
			SplashScreenManager.ShowMainSplashScreen();
			yield return StartCoroutine(Drawer.FadeIn(Parameters.GetMainLoaderParameters().FadeIn));
			yield return StartCoroutine(SplashScreenManager.Delay());
			Loader.ChangeScene(Parameters.SceneMainMenu);
		}
		
		protected override IEnumerator UnloadSceneCoroutine() {
			yield return StartCoroutine(Drawer.FadeOut(Parameters.GetMainLoaderParameters().FadeOut));
		}

	}
	
}
