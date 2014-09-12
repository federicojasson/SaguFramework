using System.Collections;

namespace SaguFramework {
	
	public class MainLoader : Loader {

		private static void LoadOptions() {
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
		}

		protected override IEnumerator LoadSceneCoroutine() {
			// TODO: debug
			//Game.NewGame();

			LoadOptions();
			SoundPlayer.StopAllSounds();
			SoundPlayer.PlayMainEffect();
			SplashScreenHandler.ShowMainSplashScreen();
			yield return StartCoroutine(GraphicHandler.FadeIn(Parameters.GetMainLoaderParameters().FadeIn));
			yield return StartCoroutine(SplashScreenHandler.Delay());
			Loader.ChangeScene(Parameters.SceneMainMenu);
		}
		
		protected override IEnumerator UnloadSceneCoroutine() {
			yield return StartCoroutine(GraphicHandler.FadeOut(Parameters.GetMainLoaderParameters().FadeOut));
		}

	}
	
}
