using System.Collections;

namespace SaguFramework {
	
	public class MainLoader : Loader {
		
		protected override IEnumerator LoadSceneCoroutine() {
			LoadOptions();

			//Game.OpenMainMenu(); TODO: uncomment
			Game.NewGame();
			
			yield break; // TODO
		}
		
		protected override IEnumerator UnloadSceneCoroutine() {
			yield break; // TODO
		}

		private void LoadOptions() {
			Options.Load();
			
			string language = Options.GetString(Parameters.OptionIdLanguage);
			Language.Load(language);

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
