using System.Xml.Linq;
using UnityEngine;

namespace SaguFramework {
	
	public static partial class LanguageManager {
		
		public static void LoadLanguage(string languageId) {
			// Gets the language file's resource path
			string resourcePath = ParameterManager.GetLanguageFileResourcePath(languageId);
			
			// Reads the language file
			XDocument languageFile = UtilityManager.ReadResourceXmlFile(resourcePath);
			
			// Processes the language file
			ProcessLanguageFile(languageFile);
		}
		
		private static void ProcessLanguageFile(XDocument languageFile) {
			// Clears the data structures
			texts.Clear();
			voices.Clear();
			
			// Language
			XElement languageNode = languageFile.Element(ParameterManager.XmlTagLanguage);
			
			// Texts
			foreach (XElement textNode in languageNode.Elements(ParameterManager.XmlTagText)) {
				XElement textIdNode = textNode.Element(ParameterManager.XmlTagId);
				string textId = UtilityManager.GetXmlNodeStringValue(textIdNode);
				XElement textValueNode = textNode.Element(ParameterManager.XmlTagValue);
				string textValue = UtilityManager.GetXmlNodeStringValue(textValueNode);
				
				// Adds the text to the corresponding data structure
				texts.Add(textId, textValue);
			}
			
			// Voices
			foreach (XElement voiceNode in languageNode.Elements(ParameterManager.XmlTagVoice)) {
				XElement voiceIdNode = voiceNode.Element(ParameterManager.XmlTagId);
				string voiceId = UtilityManager.GetXmlNodeStringValue(voiceIdNode);
				XElement voiceResourcePathNode = voiceNode.Element(ParameterManager.XmlTagResourcePath);
				string voiceResourcePath = UtilityManager.GetXmlNodeStringValue(voiceResourcePathNode);
				
				// Loads the resource
				AudioClip voice = Resources.Load<AudioClip>(voiceResourcePath);
				
				// Adds the voice to the corresponding data structure
				voices.Add(voiceId, voice);
			}
		}
		
	}
	
}
