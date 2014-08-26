using System.Collections;

namespace FrameworkNamespace {

	public class MainMenuLoader : Loader {

		protected override IEnumerator LoadSceneCoroutine() {
			GuiManager.OpenCurrentMainMenu();

			MainMenu mainMenu = GuiManager.GetCurrentMainMenu();
			
			// TODO: manager?
			GameCamera.SetTarget(mainMenu.transform);

			yield return StartCoroutine(GuiManager.FadeInCoroutine(mainMenu.FadeInParameters));
		}
		
		protected override IEnumerator UnloadSceneCoroutine() {
			MainMenu mainMenu = GuiManager.GetCurrentMainMenu();
			yield return StartCoroutine(GuiManager.FadeOutCoroutine(mainMenu.FadeOutParameters));
		}

	}

}
