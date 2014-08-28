using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

namespace SaguFramework {

	public static class LanguageManager {

		private static Dictionary<string, AudioClip> audios;
		private static Dictionary<string, string> texts;

		static LanguageManager() {
			// Initializes the data structures
			audios = new Dictionary<string, AudioClip>();
			texts = new Dictionary<string, string>();
		}

		public static AudioClip GetAudio(string audioId) {
			return audios[audioId];
		}
		
		public static string GetText(string textId) {
			return texts[textId];
		}

		public static void LoadLanguage(string languageId) {
			// Gets the language file resource path
			string resourcePath = ParameterManager.GetLanguageFileResourcePath(languageId);
			
			// Reads the language file
			XDocument languageFile = UtilityManager.ReadResourceXmlFile(resourcePath);
			
			// Processes the language file
			ProcessLanguageFile(languageFile);
		}

		private static void ProcessLanguageFile(XDocument languageFile) {
			// Clears the data structures
			audios.Clear();
			texts.Clear();

			// Gets the root node
			XElement languageNode = languageFile.Element(ParameterManager.XmlTagLanguage);

			// Audios
			foreach (XElement audioNode in languageNode.Elements(ParameterManager.XmlTagAudio)) {
				XElement audioIdNode = audioNode.Element(ParameterManager.XmlTagId);
				string audioId = UtilityManager.GetXmlNodeStringValue(audioIdNode);
				XElement audioResourcePathNode = audioNode.Element(ParameterManager.XmlTagResourcePath);
				string audioResourcePath = UtilityManager.GetXmlNodeStringValue(audioResourcePathNode);

				// Loads the resource
				AudioClip audio = Resources.Load<AudioClip>(audioResourcePath);

				// Adds the audio to the corresponding data structure
				audios.Add(audioId, audio);
			}

			// Texts
			foreach (XElement textNode in languageNode.Elements(ParameterManager.XmlTagText)) {
				XElement textIdNode = textNode.Element(ParameterManager.XmlTagId);
				string textId = UtilityManager.GetXmlNodeStringValue(textIdNode);
				XElement textValueNode = textNode.Element(ParameterManager.XmlTagValue);
				string textValue = UtilityManager.GetXmlNodeStringValue(textValueNode);
				
				// Adds the text to the corresponding data structure
				texts.Add(textId, textValue);
			}
		}

	}

}
