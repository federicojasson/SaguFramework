using System.Collections;

namespace SaguFramework {
	
	public class MainLoader : Loader {
		
		protected override IEnumerator LoadSceneCoroutine() {
			LoadOptions();
			Game.NewGame();// TODO
			SoundPlayer.GetInstance().PlayMainEffect();
			SplashScreenHandler.GetInstance().ShowMainSplashScreen();
			yield return StartCoroutine(FadeInCoroutine(Parameters.GetMainLoaderParameters().FadeIn));
			yield return StartCoroutine(Objects.GetSplashScreen().Delay());
			Game.OpenMainMenu();
		}
		
		protected override IEnumerator UnloadSceneCoroutine() {
			yield return StartCoroutine(FadeOutCoroutine(Parameters.GetMainLoaderParameters().FadeOut));
		}

		private void LoadOptions() {
			Options.Load();
			
			string languageId = Options.GetString(Parameters.OptionIdLanguage);
			Language.Load(languageId);

			float effectVolume = Options.GetFloat(Parameters.OptionIdEffectVolume);
			float masterVolume = Options.GetFloat(Parameters.OptionIdMasterVolume);
			float songVolume = Options.GetFloat(Parameters.OptionIdSongVolume);
			float voiceVolume = Options.GetFloat(Parameters.OptionIdVoiceVolume);
			SoundPlayer soundPlayer = SoundPlayer.GetInstance();
			soundPlayer.SetEffectVolume(effectVolume);
			soundPlayer.SetMasterVolume(masterVolume);
			soundPlayer.SetSongVolume(songVolume);
			soundPlayer.SetVoiceVolume(voiceVolume);
		}

	}
	
}
