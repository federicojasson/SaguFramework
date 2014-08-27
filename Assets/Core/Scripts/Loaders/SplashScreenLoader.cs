using SaguFramework.Managers;
using SaguFramework.Structures.Serializable;
using System.Collections;
using UnityEngine;

namespace SaguFramework.Loaders {
	
	public class SplashScreenLoader : Loader {

		private SplashScreenParameters splashScreenParameters;

		protected override IEnumerator LoadSceneCoroutine() {
			// Creates the splash screen
			splashScreenParameters = CreateSplashScreen();

			// TODO: fade in

			// TODO
			yield break;
		}
		
		protected override IEnumerator UnloadSceneCoroutine() {
			// TODO: fade out

			// TODO
			yield break;
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
