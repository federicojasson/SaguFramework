using SaguFramework.Managers;
using SaguFramework.Structures.Serializable;
using System.Collections;

namespace SaguFramework.Loaders {
	
	public class MainMenuLoader : Loader {

		private MainMenuParameters mainMenuParameters;
		
		protected override IEnumerator LoadSceneCoroutine() {
			// Creates the main menu
			mainMenuParameters = CreateMainMenu();
			
			// TODO: fade in
			
			// TODO
			yield break;
		}
		
		protected override IEnumerator UnloadSceneCoroutine() {
			// TODO: fade out
			
			// TODO
			yield break;
		}
		
		private MainMenuParameters CreateMainMenu() {
			// Gets the main menu's parameters
			MainMenuParameters mainMenuParameters = ParameterManager.GetMainMenuParameters();
			
			// Creates the main menu
			CreationManager.CreateMainMenu(mainMenuParameters);
			
			return mainMenuParameters;
		}

	}
	
}
