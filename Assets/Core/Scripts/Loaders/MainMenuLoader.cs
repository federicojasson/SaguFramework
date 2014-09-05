using System.Collections;

namespace SaguFramework {
	
	public class MainMenuLoader : Loader {
		
		protected override IEnumerator LoadSceneCoroutine() {
			MenuHandler.GetInstance().OpenMainMenu();

			yield break; // TODO
		}
		
		protected override IEnumerator UnloadSceneCoroutine() {
			yield break; // TODO
		}

	}
	
}
