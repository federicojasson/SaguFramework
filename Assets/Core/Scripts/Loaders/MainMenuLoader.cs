using System.Collections;

namespace SaguFramework {
	
	public class MainMenuLoader : Loader {

		private MainMenuParameters mainMenuParameters;
		
		protected override IEnumerator LoadSceneCoroutine() {
			// Creates the main menu
			mainMenuParameters = CreateMainMenu();
			
			// Fades in
			yield return StartCoroutine(Fader.GetInstance().FadeInCoroutine(mainMenuParameters.FadingIn));
		}
		
		protected override IEnumerator UnloadSceneCoroutine() {
			// Fades out
			yield return StartCoroutine(Fader.GetInstance().FadeOutCoroutine(mainMenuParameters.FadingOut));
		}
		
		private MainMenuParameters CreateMainMenu() {
			// Gets the game main menu's parameters
			MainMenuParameters gameMainMenuParameters = ParameterManager.GetGameMainMenuParameters();
			
			// Creates the main menu
			CreationManager.CreateMainMenu(gameMainMenuParameters);
			
			return gameMainMenuParameters;
		}

	}
	
}
