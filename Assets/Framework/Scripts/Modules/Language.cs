using System.Collections.Generic;

namespace SaguFramework {

	/// Handles the languages.
	/// Offers methods to load different languages automatically and to get texts and speeches.
	public static partial class Language {

		private static string currentLanguage; // The current language
		private static Dictionary<string, Speech> speeches; // The language's speeches
		private static Dictionary<string, string> texts; // The language's texts
		
		/// Performs class initialization tasks.
		static Language() {
			speeches = new Dictionary<string, Speech>();
			texts = new Dictionary<string, string>();
		}

		/// Returns the current language.
		public static string GetCurrentLanguage() {
			return currentLanguage;
		}

		/// Returns a specific speech.
		/// Receives its ID.
		public static Speech GetSpeech(string speechId) {
			return speeches[speechId];
		}

		/// Returns a specific text.
		/// Receives its ID.
		public static string GetText(string textId) {
			return texts[textId];
		}

	}
	
}
