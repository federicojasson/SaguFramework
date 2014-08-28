using System.Collections;

namespace SaguFramework {

	public class MainLoader : Loader {

		private SplashScreenParameters splashScreenParameters;
		
		protected override IEnumerator LoadSceneCoroutine() {
			// Creates the splash screen
			splashScreenParameters = CreateSplashScreen();

			// Fades in
			yield return StartCoroutine(Fader.GetInstance().FadeInCoroutine(splashScreenParameters.FadingIn));

			// TODO: load
			LanguageManager.LoadLanguage("Spanish"); // TODO: get this from options

			// Delays the execution to show the splash screen
			yield return StartCoroutine(ObjectManager.GetSplashScreen().Delay(splashScreenParameters.MinimumDelayTime));

			// Opens the main menu
			GameManager.OpenMainMenu();
		}
		
		protected override IEnumerator UnloadSceneCoroutine() {
			// Fades out
			yield return StartCoroutine(Fader.GetInstance().FadeOutCoroutine(splashScreenParameters.FadingOut));
		}
		
		private SplashScreenParameters CreateSplashScreen() {
			// Gets the game splash screens' parameters
			SplashScreenParameters gameSplashScreenParameters = ParameterManager.GetGameSplashScreenParameters();

			// Creates the splash screen
			CreationManager.CreateSplashScreen(gameSplashScreenParameters);
			
			return gameSplashScreenParameters;
		}

	}

}
