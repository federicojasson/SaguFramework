using System.Collections;

namespace FrameworkNamespace {

	public class MainLoader : Loader {
		
		protected override IEnumerator LoadSceneCoroutine() {
			GuiManager.ShowGameSplashScreen();

			SplashScreen splashScreen = GuiManager.GetCurrentSplashScreen();

			// TODO: manager?
			GameCamera.SetTarget(splashScreen.transform);

			yield return StartCoroutine(GuiManager.FadeInCoroutine(splashScreen.FadeInParameters));

			OptionManager.LoadOptions();
			string languageId = OptionManager.GetString(Parameters.LanguageOptionId);
			LanguageManager.LoadLanguage(languageId);

			yield return StartCoroutine(splashScreen.Delay());

			GameManager.LoadGameMainMenu();
		}
		
		protected override IEnumerator UnloadSceneCoroutine() {
			SplashScreen splashScreen = GuiManager.GetCurrentSplashScreen();
			yield return StartCoroutine(GuiManager.FadeOutCoroutine(splashScreen.FadeOutParameters));
		}

	}

}
