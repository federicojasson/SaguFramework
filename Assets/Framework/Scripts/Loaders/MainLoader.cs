using System.Collections;

namespace SaguFramework {

	/// Loader of the main scene.
	/// Tasks:
	/// - Load and apply options.
	/// - Show main splash screen.
	/// - Play main effect.
	public sealed class MainLoader : Loader {

		/// Loads the game options and applies those that are framework-related (mandatory options).
		private static void LoadAndApplyOptions() {
			// Loads the options
			Options.Load();

			// Gets the language's ID and loads it
			string languageId = Options.GetString(Parameters.OptionIdLanguage);
			Language.Load(languageId);

			// Gets the volume of effects and applies it
			float effectVolume = Options.GetFloat(Parameters.OptionIdEffectVolume);
			SoundPlayer.SetEffectVolume(effectVolume);

			// Gets the master volume and applies it
			float masterVolume = Options.GetFloat(Parameters.OptionIdMasterVolume);
			SoundPlayer.SetMasterVolume(masterVolume);

			// Gets the volume of music and applies it
			float songVolume = Options.GetFloat(Parameters.OptionIdSongVolume);
			SoundPlayer.SetSongVolume(songVolume);

			// Gets the volume of voices and applies it
			float voiceVolume = Options.GetFloat(Parameters.OptionIdVoiceVolume);
			SoundPlayer.SetVoiceVolume(voiceVolume);

			// Saves the current options
			// If the options file didn't exist (e.g. on first game execution), this will create it
			Options.Save();
		}

		protected override IEnumerator LoadSceneCoroutine() {
			// Loads and applies options
			LoadAndApplyOptions();

			// Plays the main effect
			SoundPlayer.PlayMainEffect();

			// Shows the main splash screen
			SplashScreenManager.ShowMainSplashScreen();

			// Fades in
			yield return StartCoroutine(Drawer.FadeIn(Parameters.GetMainLoaderParameters().FadeIn));

			// Delays the execution to show the splash screen
			yield return StartCoroutine(SplashScreenManager.Delay());

			// Changes to the main menu scene
			Loader.ChangeScene(Parameters.SceneMainMenu);
		}

		protected override IEnumerator UnloadSceneCoroutine() {
			// Fades out
			yield return StartCoroutine(Drawer.FadeOut(Parameters.GetMainLoaderParameters().FadeOut));
		}

	}
	
}
