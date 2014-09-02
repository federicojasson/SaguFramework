using System.Collections.Generic;
using UnityEngine;

namespace SaguFramework {

	public static partial class LanguageManager {

		private static Dictionary<string, string> texts;
		private static Dictionary<string, AudioClip> voices;

		static LanguageManager() {
			// Initializes the data structures
			texts = new Dictionary<string, string>();
			voices = new Dictionary<string, AudioClip>();
		}
		
		public static string GetText(string textId) {
			return texts[textId];
		}
		
		public static AudioClip GetVoice(string voiceId) {
			return voices[voiceId];
		}

	}

}
