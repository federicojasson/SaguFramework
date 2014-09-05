using System.Collections;

namespace SaguFramework {
	
	public class MainMenuLoader : Loader {
		
		protected override IEnumerator LoadSceneCoroutine() {
			SoundPlayer.GetInstance().PlayMainMenuSong();
			MenuHandler.GetInstance().OpenMainMenu();
			yield return StartCoroutine(FadeInCoroutine(Parameters.GetMainMenuLoaderParameters().FadeIn));
		}
		
		protected override IEnumerator UnloadSceneCoroutine() {
			yield return StartCoroutine(FadeOutCoroutine(Parameters.GetMainMenuLoaderParameters().FadeOut));
			SoundPlayer.GetInstance().PlayPlaylist();
		}

	}
	
}
