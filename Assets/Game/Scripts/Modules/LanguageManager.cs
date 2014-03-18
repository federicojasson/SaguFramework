using System.Collections.Generic;
using UnityEngine;

public static class LanguageManager {

	private static Dictionary<string, Speech> speeches;
	private static Dictionary<string, string> texts;

	static LanguageManager() {
		speeches = new Dictionary<string, Speech>();
		texts = new Dictionary<string, string>();
	}

	public static Speech GetSpeech(string id) {
		return speeches[id];
	}

	public static string GetText(string id) {
		return texts[id];
	}

	public static void LoadLanguage(string languageId) {
		// TODO: load from XML
		//Resources.Load(P.LANGUAGE_FILE_PATH(languageId));
		UnityEngine.Debug.Log("TODO: load language from XML: " + P.LANGUAGE_FILE_PATH(languageId));

		speeches.Clear();
		texts.Clear();

		// TODO

		speeches.Add("ERLENMEYER_ON_LOOK", new Speech("Es un Erlenmeyer", (AudioClip) Resources.Load(P.LANGUAGE_AUDIO_PATH(languageId, "ErlenmeyerOnLook"))));

		texts.Add("LABORATORY_MAP_TELEPORTER_CURSOR_LABEL", "Salir del laboratorio");
		texts.Add("ERLENMEYER_CURSOR_LABEL", "Erlenmeyer");
	}

}                                                                                                                                                                                                                                                                                                                                                                     
