using System.Collections;

namespace SaguFramework {
	
	public class MainMenuLoader : Loader {

		protected override IEnumerator LoadSceneCoroutine() {
			// Stops any playing song
			AudioPlayer.GetInstance().StopSongs();

			// Plays the main menu song
			AudioPlayer.GetInstance().PlaySong(ParameterManager.GetMainMenuSong());

			// Creates the menu
			CreateMenu();
			
			// Fades in
			yield return StartCoroutine(Masker.GetInstance().FadeInCoroutine(ParameterManager.GetMainMenuLoaderParameters().FadingIn));
		}
		
		protected override IEnumerator UnloadSceneCoroutine() {
			// Fades out
			yield return StartCoroutine(Masker.GetInstance().FadeOutCoroutine(ParameterManager.GetMainMenuLoaderParameters().FadingOut));
			
			// Stops the main menu song
			AudioPlayer.GetInstance().StopSongs();
			
			// Starts playing the songs
			AudioPlayer.GetInstance().PlaySongs(ParameterManager.GetSongs());
		}
		
		private void CreateMenu() {
			// Gets the main menu's parameters
			MenuParameters mainMenuParameters = ParameterManager.GetMainMenuParameters();
			
			// Creates the menu
			CreationManager.CreateMenu(mainMenuParameters);
		}

	}
	
}
