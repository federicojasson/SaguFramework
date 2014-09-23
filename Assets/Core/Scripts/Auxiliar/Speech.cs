using UnityEngine;

namespace SaguFramework {

	/// Represents a character's speech.
	/// Speech objects are sent to characters in order to make them say something.
	public sealed class Speech {

		private string text; // The text to show in the screen
		private AudioClip voice; // The recorded voice audio
		
		/// Initializes a character's speech.
		/// It receives its text and voice audio.
		public Speech(string text, AudioClip voice) {
			this.text = text;
			this.voice = voice;
		}

		/// Gets the speech's text.
		public string GetText() {
			return text;
		}
		
		/// Gets the speech's voice audio.
		public AudioClip GetVoice() {
			return voice;
		}

	}
	
}
