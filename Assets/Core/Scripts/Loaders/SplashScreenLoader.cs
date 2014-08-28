using System.Collections;
using UnityEngine;

namespace SaguFramework {
	
	public class SplashScreenLoader : Loader {

		private SplashScreenParameters splashScreenParameters;

		protected override IEnumerator LoadSceneCoroutine() {
			// Creates the splash screen
			splashScreenParameters = CreateSplashScreen();

			// Fades in
			yield return StartCoroutine(Fader.GetInstance().FadeInCoroutine(splashScreenParameters.FadingIn));

			// Delays the execution to show the splash screen
			yield return StartCoroutine(ObjectManager.GetSplashScreen().Delay(splashScreenParameters.MinimumDelayTime));

			// Loads the room scene
			LoadScene(ParameterManager.SceneRoom);
		}
		
		protected override IEnumerator UnloadSceneCoroutine() {
			// Fades out
			yield return StartCoroutine(Fader.GetInstance().FadeOutCoroutine(splashScreenParameters.FadingOut));
		}

		private SplashScreenParameters CreateSplashScreen() {
			// Gets the splash screens' parameters
			SplashScreenParameters[] splashScreensParameters = ParameterManager.GetSplashScreensParameters();
			
			// Selects a random splash screen
			int randomIndex = Random.Range(0, splashScreensParameters.Length);
			SplashScreenParameters splashScreenParameters = splashScreensParameters[randomIndex];
			
			// Creates the splash screen
			CreationManager.CreateSplashScreen(splashScreenParameters);

			return splashScreenParameters;
		}

	}
	
}
