﻿using System.Collections.Generic;

namespace SaguFramework {
	
	public static partial class Language {
		
		private static Dictionary<string, Speech> speeches;
		private static Dictionary<string, string> texts;
		
		static Language() {
			speeches = new Dictionary<string, Speech>();
			texts = new Dictionary<string, string>();
		}
		
		public static Speech GetSpeech(string speechId) {
			return speeches[speechId];
		}
		
		public static string GetText(string textId) {
			return texts[textId];
		}

	}
	
}
