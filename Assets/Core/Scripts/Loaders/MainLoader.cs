using System.Collections;

namespace SaguFramework {

	public class MainLoader : Loader {
		
		protected override IEnumerator LoadSceneCoroutine() {
			// Plays the main song
			AudioPlayer.GetInstance().PlaySong(ParameterManager.GetMainSong());

			// Creates the splash screen
			SplashScreenParameters splashScreenParameters = CreateSplashScreen();

			// Fades in
			yield return StartCoroutine(Masker.GetInstance().FadeInCoroutine(ParameterManager.GetMainLoaderParameters().FadingIn));

			// TODO: load
			LanguageManager.LoadLanguage("Spanish"); // TODO: get this from options

			// Delays the execution to show the splash screen
			yield return StartCoroutine(ObjectManager.GetSplashScreen().Delay(splashScreenParameters.MinimumDelayTime));

			// Opens the main menu
			GameManager.OpenMainMenu();
		}
		
		protected override IEnumerator UnloadSceneCoroutine() {
			// Fades out
			yield return StartCoroutine(Masker.GetInstance().FadeOutCoroutine(ParameterManager.GetMainLoaderParameters().FadingOut));

			// Stops the main song
			AudioPlayer.GetInstance().StopSongs();
		}
		
		private SplashScreenParameters CreateSplashScreen() {
			// Gets the game splash screen's parameters
			SplashScreenParameters gameSplashScreenParameters = ParameterManager.GetGameSplashScreenParameters();

			// Creates the splash screen
			CreationManager.CreateSplashScreen(gameSplashScreenParameters);
			
			return gameSplashScreenParameters;
		}

	}

}
