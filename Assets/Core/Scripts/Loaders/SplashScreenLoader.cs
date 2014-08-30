using System.Collections;
using UnityEngine;

namespace SaguFramework {
	
	public class SplashScreenLoader : Loader {

		protected override IEnumerator LoadSceneCoroutine() {
			// Creates the splash screen
			SplashScreenParameters splashScreenParameters = CreateSplashScreen();

			// Fades in
			yield return StartCoroutine(Masker.GetInstance().FadeInCoroutine(ParameterManager.GetSplashScreenLoaderParameters().FadingIn));

			// Delays the execution to show the splash screen
			yield return StartCoroutine(ObjectManager.GetSplashScreen().Delay(splashScreenParameters.MinimumDelayTime));

			// Loads the room scene
			LoadScene(ParameterManager.SceneRoom);
		}
		
		protected override IEnumerator UnloadSceneCoroutine() {
			// Fades out
			yield return StartCoroutine(Masker.GetInstance().FadeOutCoroutine(ParameterManager.GetSplashScreenLoaderParameters().FadingOut));
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
