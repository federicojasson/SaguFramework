using UnityEngine;

namespace SaguFramework {
	
	public sealed class Speech {

		private string text;
		private AudioClip voice;

		public Speech(string text, AudioClip voice) {
			this.text = text;
			this.voice = voice;
		}

		public string GetText() {
			return text;
		}

		public AudioClip GetVoice() {
			return voice;
		}

	}
	
}
