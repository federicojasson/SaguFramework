using System.Collections;

namespace SaguFramework {
	
	public class MainMenuLoader : Loader {

		protected override IEnumerator LoadSceneCoroutine() {
			// Creates the menu
			CreateMenu();
			
			// Fades in
			yield return StartCoroutine(Masker.GetInstance().FadeInCoroutine(ParameterManager.GetMainMenuLoaderParameters().FadingIn));
		}
		
		protected override IEnumerator UnloadSceneCoroutine() {
			// Fades out
			yield return StartCoroutine(Masker.GetInstance().FadeOutCoroutine(ParameterManager.GetMainMenuLoaderParameters().FadingOut));
		}
		
		private void CreateMenu() {
			// Gets the main menu's parameters
			MenuParameters mainMenuParameters = ParameterManager.GetMainMenuParameters();
			
			// Creates the menu
			CreationManager.CreateMenu(mainMenuParameters);
		}

	}
	
}
