using System.Xml.Linq;
using UnityEngine;

namespace SaguFramework {

	/// Handles the languages.
	/// Offers methods to load different languages automatically and to get texts and speeches.
	public static partial class Language {

		/// Load a specific language.
		/// Receives its ID.
		public static void Load(string languageId) {
			currentLanguage = languageId;
			string resourcePath = Parameters.GetLanguageFileResourcePath(languageId);
			XDocument file = Utilities.ReadResourceXmlFile(resourcePath);
			ProcessLanguageFile(file);
		}

		/// Processes a language file.
		private static void ProcessLanguageFile(XDocument file) {
			// Resets the values
			speeches.Clear();
			texts.Clear();
			
			// Language
			XElement languageNode = file.Element(Parameters.XmlNodeLanguage);
			
			// Texts
			foreach (XElement textNode in languageNode.Elements(Parameters.XmlNodeText)) {
				XAttribute idAttribute = textNode.Attribute(Parameters.XmlAttributeId);

				string id = Utilities.GetXmlAttributeStringValue(idAttribute);
				string text = Utilities.GetXmlNodeStringValue(textNode);
				
				texts.Add(id, text);
			}
			
			// Speeches
			foreach (XElement speechNode in languageNode.Elements(Parameters.XmlNodeSpeech)) {
				XAttribute idAttribute = speechNode.Attribute(Parameters.XmlAttributeId);
				XElement textNode = speechNode.Element(Parameters.XmlNodeText);
				XElement voiceNode = speechNode.Element(Parameters.XmlNodeVoice);

				string id = Utilities.GetXmlAttributeStringValue(idAttribute);
				string text = Utilities.GetXmlNodeStringValue(textNode);
				string voiceResourcePath = Utilities.GetXmlNodeStringValue(voiceNode);
				AudioClip voice = Resources.Load<AudioClip>(voiceResourcePath);
				Speech speech = new Speech(text, voice);

				speeches.Add(id, speech);
			}
		}

	}
	
}
