using System.Xml.Linq;
using UnityEngine;

namespace SaguFramework {
	
	public static partial class Language {
		
		public static void Load(string id) {
			string resourcePath = Parameters.GetLanguageFileResourcePath(id);
			XDocument file = Utilities.ReadResourceXmlFile(resourcePath);
			ProcessLanguageFile(file);
		}
		
		private static void ProcessLanguageFile(XDocument file) {
			texts.Clear();
			voices.Clear();
			
			// Language
			XElement languageNode = file.Element(Parameters.XmlTagLanguage);
			
			// Texts
			foreach (XElement textNode in languageNode.Elements(Parameters.XmlTagText)) {
				XElement idNode = textNode.Element(Parameters.XmlTagId);
				string id = Utilities.GetXmlNodeStringValue(idNode);
				XElement valueNode = textNode.Element(Parameters.XmlTagValue);
				string value = Utilities.GetXmlNodeStringValue(valueNode);

				texts.Add(id, value);
			}
			
			// Voices
			foreach (XElement voiceNode in languageNode.Elements(Parameters.XmlTagVoice)) {
				XElement voiceIdNode = voiceNode.Element(Parameters.XmlTagId);
				string id = Utilities.GetXmlNodeStringValue(voiceIdNode);
				XElement voiceResourcePathNode = voiceNode.Element(Parameters.XmlTagResourcePath);
				string resourcePath = Utilities.GetXmlNodeStringValue(voiceResourcePathNode);

				AudioClip voice = Resources.Load<AudioClip>(resourcePath);

				voices.Add(id, voice);
			}
		}

	}
	
}
