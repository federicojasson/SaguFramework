using UnityEngine;

namespace SaguFramework {

	/// Represents a speech.
	/// Speech objects are sent to characters in order to make them say something.
	public sealed class Speech {

		private string text; // The text to show in the screen
		private AudioClip voice; // The recorded audio voice
		
		/// Initializes a speech.
		/// Receives its text and audio voice.
		public Speech(string text, AudioClip voice) {
			this.text = text;
			this.voice = voice;
		}

		/// Returns the speech's text.
		public string GetText() {
			return text;
		}
		
		/// Returns the speech's audio voice.
		public AudioClip GetVoice() {
			return voice;
		}

	}
	
}
