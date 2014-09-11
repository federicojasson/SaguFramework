using System.Collections.Generic;
using UnityEngine;

namespace SaguFramework {
	
	public static partial class Language {

		private static Dictionary<string, string> texts;
		private static Dictionary<string, AudioClip> voices;
		
		static Language() {
			texts = new Dictionary<string, string>();
			voices = new Dictionary<string, AudioClip>();
		}
		
		public static string GetText(string id) {
			return texts[id];
		}
		
		public static AudioClip GetVoice(string id) {
			return voices[id];
		}

	}
	
}
