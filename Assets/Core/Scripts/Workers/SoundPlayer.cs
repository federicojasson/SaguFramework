using UnityEngine;

namespace SaguFramework {
	
	public class SoundPlayer : Worker {
		
		private static SoundPlayer instance;
		
		public static SoundPlayer GetInstance() {
			return instance;
		}

		private AudioSource effectPlayer;
		private AudioSource songPlayer;
		private AudioSource voicePlayer;

		public override void Awake() {
			base.Awake();
			instance = this;
			gameObject.AddComponent<AudioListener>();
			effectPlayer = gameObject.AddComponent<AudioSource>();
			songPlayer = gameObject.AddComponent<AudioSource>();
			voicePlayer = gameObject.AddComponent<AudioSource>();
		}
		
		public void SetEffectVolume(float volume) {
			effectPlayer.volume = volume;
		}
		
		public void SetMasterVolume(float volume) {
			AudioListener.volume = volume;
		}
		
		public void SetSongVolume(float volume) {
			songPlayer.volume = volume;
		}
		
		public void SetVoiceVolume(float volume) {
			voicePlayer.volume = volume;
		}

	}
	
}
