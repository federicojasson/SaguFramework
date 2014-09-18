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
