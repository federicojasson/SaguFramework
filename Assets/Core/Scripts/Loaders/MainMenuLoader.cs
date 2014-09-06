using System.Collections;

namespace SaguFramework {
	
	public class MainMenuLoader : Loader {
		
		protected override IEnumerator LoadSceneCoroutine() {
			SoundPlayer.GetInstance().PlayMainMenuSong();
			MenuHandler.GetInstance().OpenMainMenu();
			InputHandler.GetInstance().SetInputMode(InputMode.MainMenu);
			yield return StartCoroutine(FadeInCoroutine(Parameters.GetMainMenuLoaderParameters().FadeIn));
		}
		
		protected override IEnumerator UnloadSceneCoroutine() {
			InputHandler.GetInstance().SetInputMode(InputMode.Disabled);
			yield return StartCoroutine(FadeOutCoroutine(Parameters.GetMainMenuLoaderParameters().FadeOut));
			SoundPlayer.GetInstance().PlayPlaylist();
		}

	}
	
}
