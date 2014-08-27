using SaguFramework.Managers;
using SaguFramework.Structures.Serializable;
using System.Collections;

namespace SaguFramework.Loaders {

	public class MainLoader : Loader {

		private SplashScreenParameters splashScreenParameters;
		
		protected override IEnumerator LoadSceneCoroutine() {
			// Creates the splash screen
			splashScreenParameters = CreateSplashScreen();
			
			// TODO: fade in
			
			// TODO
			yield break;

			// Opens the main menu
			GameManager.OpenMainMenu();
		}
		
		protected override IEnumerator UnloadSceneCoroutine() {
			// TODO: fade out
			
			// TODO
			yield break;
		}
		
		private SplashScreenParameters CreateSplashScreen() {
			// Gets the main splash screens' parameters
			SplashScreenParameters mainSplashScreenParameters = ParameterManager.GetMainSplashScreenParameters();

			// Creates the splash screen
			CreationManager.CreateSplashScreen(mainSplashScreenParameters);
			
			return splashScreenParameters;
		}

	}

}
