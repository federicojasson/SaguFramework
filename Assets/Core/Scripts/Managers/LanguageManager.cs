using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using UnityEngine;

namespace FrameworkNamespace {

	public static class LanguageManager {

		private static Dictionary<string, AudioClip> audios;
		private static Dictionary<string, string> texts;

		static LanguageManager() {
			audios = new Dictionary<string, AudioClip>();
			texts = new Dictionary<string, string>();
		}

		public static AudioClip GetAudio(string id) {
			return audios[id];
		}

		public static string GetText(string id) {
			return texts[id];
		}

		public static void LoadLanguage(string id) {
			string resourcePath = GetLanguageFileResourcePath(id);
			XDocument languageFile = UtilityManager.ReadResourceXmlFile(resourcePath);
			LoadLanguageFile(languageFile);
		}

		private static string GetLanguageFileResourcePath(string id) {
			// TODO: maybe do something else in UtilityManager or Parameters
			
			string languageFileResourcePath = "";
			languageFileResourcePath += Parameters.LanguagesDirectoryResourcePath;
			languageFileResourcePath += "/";
			languageFileResourcePath += id;
			languageFileResourcePath += "/";
			languageFileResourcePath += Parameters.LanguageFilename;
			
			return languageFileResourcePath;
		}

		// TODO: refactor XML handling

		private static void LoadLanguageFile(XDocument languageFile) {
			audios.Clear();
			texts.Clear();

			XElement root = languageFile.Root;

			foreach (XElement node in root.Elements(Parameters.XmlTagAudio)) {
				string id = node.Element(Parameters.XmlTagId).Value.Trim();
				string resourcePath = node.Element(Parameters.XmlTagResourcePath).Value.Trim();

				AudioClip audio = UtilityManager.LoadResource<AudioClip>(resourcePath);

				audios.Add (id, audio);
			}
			
			foreach (XElement node in root.Elements(Parameters.XmlTagText)) {
				string id = node.Element(Parameters.XmlTagId).Value.Trim();
				string value = node.Element(Parameters.XmlTagValue).Value.Trim();

				texts.Add(id, value);
			}
		}

	}

}
