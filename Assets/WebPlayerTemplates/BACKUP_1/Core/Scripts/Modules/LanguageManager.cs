using System;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

//
// LanguageManager - Module class
//
// TODO: write class description
//
public static class LanguageManager {

	private static Dictionary<string, AudioClip> audios;
	private static Dictionary<string, string> texts;

	static LanguageManager() {
		audios = new Dictionary<string, AudioClip>();
		texts = new Dictionary<string, string>();
	}
	
	public static AudioClip GetAudio(string id) {
		AudioClip audio;
		if (! audios.TryGetValue(id, out audio))
			// The audio was not found
			ErrorManager.Terminate("LanguageManager", "The audio \"" + id + "\" was not found");
		
		return audio;
	}

	public static string GetText(string id) {
		string text;
		if (! texts.TryGetValue(id, out text))
			// The text was not found
			ErrorManager.Terminate("LanguageManager", "The text \"" + id + "\" was not found");

		return text;
	}

	public static void LoadLanguage(string id) {
		// Discards all current audios and texts
		audios.Clear();
		texts.Clear();

		TextAsset textFile = (TextAsset) Resources.Load(C.FILE_PATH_LANGUAGE_TEXTS(id), typeof(TextAsset));
		if (textFile == null)
			// The language texts file was not found
			ErrorManager.Terminate("LanguageManager", "The language texts file was not found");

		try {
			XElement root = XDocument.Parse(textFile.text).Root;

			foreach (XElement node in root.Elements())
				if (node.Name.LocalName.Equals(C.TEXT_TAG)) {
					string key = node.Attribute(C.TEXT_ATTRIBUTE_ID).Value.Trim();
					string value = node.Value.Trim();
					texts.Add(key, value);
				}
		} catch (Exception) {
			// The language texts file couldn't be parsed
			ErrorManager.Terminate("LanguageManager", "The language texts file couldn't be parsed");
		}

		TextAsset audioFile = (TextAsset) Resources.Load(C.FILE_PATH_LANGUAGE_AUDIOS(id), typeof(TextAsset));
		if (audioFile == null)
			// The language audios file was not found
			ErrorManager.Terminate("LanguageManager", "The language audios file was not found");
		
		try {
			XElement root = XDocument.Parse(audioFile.text).Root;
			
			foreach (XElement node in root.Elements())
				if (node.Name.LocalName.Equals(C.AUDIO_TAG)) {
					string key = node.Attribute(C.AUDIO_ATTRIBUTE_ID).Value.Trim();
					string relativePath = node.Value.Trim();
					AudioClip value = (AudioClip) Resources.Load(C.FILE_PATH_LANGUAGE_AUDIO(id, relativePath), typeof(AudioClip));;
					audios.Add(key, value);
				}
		} catch (Exception) {
			// The language audios file couldn't be parsed
			ErrorManager.Terminate("LanguageManager", "The language audios file couldn't be parsed");
		}
	}

}
