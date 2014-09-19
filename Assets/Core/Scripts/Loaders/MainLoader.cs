using System.Collections;

namespace SaguFramework {
	
	public sealed class MainLoader : Loader {

		private static void LoadAndApplyOptions() {
			Options.Load();

			string languageId = Options.GetString(Parameters.OptionIdLanguage);
			Language.Load(languageId);

			float effectVolume = Options.GetFloat(Parameters.OptionIdEffectVolume);
			SoundPlayer.SetEffectVolume(effectVolume);

			float masterVolume = Options.GetFloat(Parameters.OptionIdMasterVolume);
			SoundPlayer.SetMasterVolume(masterVolume);

			float songVolume = Options.GetFloat(Parameters.OptionIdSongVolume);
			SoundPlayer.SetSongVolume(songVolume);

			float voiceVolume = Options.GetFloat(Parameters.OptionIdVoiceVolume);
			SoundPlayer.SetVoiceVolume(voiceVolume);

			Options.Save();
		}

		protected override IEnumerator LoadSceneCoroutine() {
			LoadAndApplyOptions();

			// TODO: debug
			Framework.NewGame();
			//Game.OpenMainMenu();

			SoundPlayer.StopAllSounds();
			SoundPlayer.PlayMainEffect();
			SplashScreenManager.ShowMainSplashScreen();
			yield return StartCoroutine(Drawer.FadeIn(Parameters.GetMainLoaderParameters().FadeIn));
			yield return StartCoroutine(SplashScreenManager.Delay());
			Loader.ChangeScene(Parameters.SceneMainMenu);
		}
		
		protected override IEnumerator UnloadSceneCoroutine() {
			yield return StartCoroutine(Drawer.FadeOut(Parameters.GetMainLoaderParameters().FadeOut));
		}

	}
	
}
