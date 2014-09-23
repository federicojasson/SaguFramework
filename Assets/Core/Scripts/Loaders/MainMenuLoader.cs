using System.Collections;

namespace SaguFramework {

	/// Loader of the main scene.
	/// Tasks:
	/// - Play main menu song.
	/// - Open main menu.
	/// - Play song playlist.
	public sealed class MainMenuLoader : Loader {
		
		/// Performs the loading tasks.
		protected override IEnumerator LoadSceneCoroutine() {
			// Plays the main menu song
			SoundPlayer.StopAllSounds();
			SoundPlayer.PlayMainMenuSong();

			// Opens the main menu
			MenuManager.OpenMainMenu();

			// Fades in
			yield return StartCoroutine(Drawer.FadeIn(Parameters.GetMainMenuLoaderParameters().FadeIn));
		}
		
		/// Performs the unloading tasks.
		protected override IEnumerator UnloadSceneCoroutine() {
			// Fades out
			yield return StartCoroutine(Drawer.FadeOut(Parameters.GetMainMenuLoaderParameters().FadeOut));

			// Starts playing the songs of the playlist
			SoundPlayer.StopAllSounds();
			SoundPlayer.PlayPlaylist();
		}

	}
	
}
