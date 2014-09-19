using System.Collections;

namespace SaguFramework {
	
	public sealed class MainMenuLoader : Loader {
		
		protected override IEnumerator LoadSceneCoroutine() {
			SoundPlayer.StopAllSounds();
			SoundPlayer.PlayMainMenuSong();
			MenuManager.OpenMainMenu();
			yield return StartCoroutine(Drawer.FadeIn(Parameters.GetMainMenuLoaderParameters().FadeIn));
		}
		
		protected override IEnumerator UnloadSceneCoroutine() {
			yield return StartCoroutine(Drawer.FadeOut(Parameters.GetMainMenuLoaderParameters().FadeOut));
			SoundPlayer.StopAllSounds();
			SoundPlayer.PlayPlaylist();
		}

	}
	
}
