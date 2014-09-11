using UnityEngine;

namespace SaguFramework {
	
	public class SoundPlayer : Worker {

		private static SoundPlayer instance;

		public static void SetEffectVolume(float volume) {
			// TODO
		}

		public static void SetMasterVolume(float volume) {
			AudioListener.volume = volume;
		}

		public static void SetSongVolume(float volume) {
			// TODO
		}

		public static void SetVoiceVolume(float volume) {
			// TODO
		}
		
		public override void Awake() {
			base.Awake();
			instance = this;
			gameObject.AddComponent<AudioListener>();
		}
		
	}
	
}
