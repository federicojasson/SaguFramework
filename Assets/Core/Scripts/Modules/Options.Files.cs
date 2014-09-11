using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace SaguFramework {
	
	public static partial class Options {
		
		public static void Load() {
			try {
				string path = Parameters.GetOptionsFilePath();
				XDocument file = Utilities.ReadXmlFile(path);
				ProcessOptionsFile(file);
			} catch (Exception) {
				// There was a problem reading or processing the options file
				string resourcePath = Parameters.InitialOptionsFileResourcePath;
				XDocument file = Utilities.ReadResourceXmlFile(resourcePath);
				ProcessOptionsFile(file);
				Save();
			}
		}
		
		public static void Save() {
			XDocument file = GenerateOptionsFile();
			string path = Parameters.GetOptionsFilePath();
			Utilities.WriteXmlFile(path, file);
		}
		
		private static XDocument GenerateOptionsFile() {
			// Options
			XElement optionsNode = new XElement(Parameters.XmlTagOptions);
			
			// Booleans
			foreach (KeyValuePair<string, bool> entry in booleans) {
				XElement booleanNode = new XElement(Parameters.XmlTagBoolean);
				
				XElement idNode = new XElement(Parameters.XmlTagId);
				Utilities.SetXmlNodeStringValue(idNode, entry.Key);
				
				XElement valueNode = new XElement(Parameters.XmlTagValue);
				Utilities.SetXmlNodeBooleanValue(valueNode, entry.Value);
				
				booleanNode.Add(idNode, valueNode);
				optionsNode.Add(booleanNode);
			}
			
			// Floats
			foreach (KeyValuePair<string, float> entry in floats) {
				XElement floatNode = new XElement(Parameters.XmlTagFloat);
				
				XElement idNode = new XElement(Parameters.XmlTagId);
				Utilities.SetXmlNodeStringValue(idNode, entry.Key);
				
				XElement valueNode = new XElement(Parameters.XmlTagValue);
				Utilities.SetXmlNodeFloatValue(valueNode, entry.Value);
				
				floatNode.Add(idNode, valueNode);
				optionsNode.Add(floatNode);
			}
			
			// Integers
			foreach (KeyValuePair<string, int> entry in integers) {
				XElement integerNode = new XElement(Parameters.XmlTagInteger);
				
				XElement idNode = new XElement(Parameters.XmlTagId);
				Utilities.SetXmlNodeStringValue(idNode, entry.Key);
				
				XElement valueNode = new XElement(Parameters.XmlTagValue);
				Utilities.SetXmlNodeIntegerValue(valueNode, entry.Value);
				
				integerNode.Add(idNode, valueNode);
				optionsNode.Add(integerNode);
			}
			
			// Strings
			foreach (KeyValuePair<string, string> entry in strings) {
				XElement stringNode = new XElement(Parameters.XmlTagString);
				
				XElement idNode = new XElement(Parameters.XmlTagId);
				Utilities.SetXmlNodeStringValue(idNode, entry.Key);
				
				XElement valueNode = new XElement(Parameters.XmlTagValue);
				Utilities.SetXmlNodeStringValue(valueNode, entry.Value);
				
				stringNode.Add(idNode, valueNode);
				optionsNode.Add(stringNode);
			}
			
			return new XDocument(optionsNode);
		}
		
		private static void ProcessOptionsFile(XDocument file) {
			booleans.Clear();
			floats.Clear();
			integers.Clear();
			strings.Clear();
			
			// Options
			XElement optionsNode = file.Element(Parameters.XmlTagOptions);
			
			// Booleans
			foreach (XElement booleanNode in optionsNode.Elements(Parameters.XmlTagBoolean)) {
				XElement idNode = booleanNode.Element(Parameters.XmlTagId);
				string id = Utilities.GetXmlNodeStringValue(idNode);
				XElement valueNode = booleanNode.Element(Parameters.XmlTagValue);
				bool value = Utilities.GetXmlNodeBooleanValue(valueNode);
				
				booleans.Add(id, value);
			}
			
			// Floats
			foreach (XElement floatNode in optionsNode.Elements(Parameters.XmlTagFloat)) {
				XElement idNode = floatNode.Element(Parameters.XmlTagId);
				string id = Utilities.GetXmlNodeStringValue(idNode);
				XElement valueNode = floatNode.Element(Parameters.XmlTagValue);
				float value = Utilities.GetXmlNodeFloatValue(valueNode);
				
				floats.Add(id, value);
			}
			
			// Integers
			foreach (XElement integerNode in optionsNode.Elements(Parameters.XmlTagInteger)) {
				XElement idNode = integerNode.Element(Parameters.XmlTagId);
				string id = Utilities.GetXmlNodeStringValue(idNode);
				XElement valueNode = integerNode.Element(Parameters.XmlTagValue);
				int value = Utilities.GetXmlNodeIntegerValue(valueNode);
				
				integers.Add(id, value);
			}
			
			// Strings
			foreach (XElement stringNode in optionsNode.Elements(Parameters.XmlTagString)) {
				XElement idNode = stringNode.Element(Parameters.XmlTagId);
				string id = Utilities.GetXmlNodeStringValue(idNode);
				XElement valueNode = stringNode.Element(Parameters.XmlTagValue);
				string value = Utilities.GetXmlNodeStringValue(valueNode);
				
				strings.Add(id, value);
			}
		}

	}
	
}
