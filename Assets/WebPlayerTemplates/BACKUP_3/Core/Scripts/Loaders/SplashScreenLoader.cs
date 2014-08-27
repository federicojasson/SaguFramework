using System.Collections;

namespace FrameworkNamespace {

	public class SplashScreenLoader : Loader {

		protected override IEnumerator LoadSceneCoroutine() {
			GuiManager.ShowRoomSplashScreen();
			
			SplashScreen splashScreen = GuiManager.GetCurrentSplashScreen();

			// TODO: manager?
			GameCamera.SetTarget(splashScreen.transform);

			yield return StartCoroutine(GuiManager.FadeInCoroutine(splashScreen.FadeInParameters));

			yield return StartCoroutine(splashScreen.Delay());

			GameManager.LoadRoom(false);
		}
		
		protected override IEnumerator UnloadSceneCoroutine() {
			SplashScreen splashScreen = GuiManager.GetCurrentSplashScreen();
			yield return StartCoroutine(GuiManager.FadeOutCoroutine(splashScreen.FadeOutParameters));
		}

	}

}
