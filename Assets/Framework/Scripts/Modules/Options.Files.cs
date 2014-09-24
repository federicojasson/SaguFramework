using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace SaguFramework {
	
	/// Handles the options.
	/// Offers methods to load them automatically and to get them.
	public static partial class Options {

		/// Loads the options.
		public static void Load() {
			try {
				string path = Parameters.GetOptionsFilePath();
				XDocument file = Utilities.ReadXmlFile(path);
				ProcessOptionsFile(file);
			} catch (Exception) {
				// There was a problem reading or processing the options file
				string resourcePath = Parameters.DefaultOptionsFileResourcePath;
				XDocument file = Utilities.ReadResourceXmlFile(resourcePath);
				ProcessOptionsFile(file);
			}
		}

		/// Saves the current options.
		public static void Save() {
			XDocument file = GenerateOptionsFile();
			string path = Parameters.GetOptionsFilePath();
			Utilities.WriteXmlFile(path, file);
		}
		
		/// Generates an options file from the current options.
		private static XDocument GenerateOptionsFile() {
			// Options
			XElement optionsNode = new XElement(Parameters.XmlNodeOptions);
			
			// Booleans
			foreach (KeyValuePair<string, bool> entry in booleans) {
				XAttribute idAttribute = new XAttribute(Parameters.XmlAttributeId, string.Empty);
				XElement booleanNode = new XElement(Parameters.XmlNodeBoolean);

				string id = entry.Key;
				bool value = entry.Value;

				Utilities.SetXmlAttributeStringValue(idAttribute, id);
				Utilities.SetXmlNodeBooleanValue(booleanNode, value);

				booleanNode.Add(idAttribute);
				optionsNode.Add(booleanNode);
			}
			
			// Floats
			foreach (KeyValuePair<string, float> entry in floats) {
				XAttribute idAttribute = new XAttribute(Parameters.XmlAttributeId, string.Empty);
				XElement floatNode = new XElement(Parameters.XmlNodeFloat);
				
				string id = entry.Key;
				float value = entry.Value;

				Utilities.SetXmlAttributeStringValue(idAttribute, id);
				Utilities.SetXmlNodeFloatValue(floatNode, value);
				
				floatNode.Add(idAttribute);
				optionsNode.Add(floatNode);
			}
			
			// Integers
			foreach (KeyValuePair<string, int> entry in integers) {
				XAttribute idAttribute = new XAttribute(Parameters.XmlAttributeId, string.Empty);
				XElement integerNode = new XElement(Parameters.XmlNodeInteger);
				
				string id = entry.Key;
				int value = entry.Value;

				Utilities.SetXmlAttributeStringValue(idAttribute, id);
				Utilities.SetXmlNodeIntegerValue(integerNode, value);
				
				integerNode.Add(idAttribute);
				optionsNode.Add(integerNode);
			}
			
			// Strings
			foreach (KeyValuePair<string, string> entry in strings) {
				XAttribute idAttribute = new XAttribute(Parameters.XmlAttributeId, string.Empty);
				XElement stringNode = new XElement(Parameters.XmlNodeString);
				
				string id = entry.Key;
				string value = entry.Value;

				Utilities.SetXmlAttributeStringValue(idAttribute, id);
				Utilities.SetXmlNodeStringValue(stringNode, value);
				
				stringNode.Add(idAttribute);
				optionsNode.Add(stringNode);
			}
			
			return new XDocument(optionsNode);
		}
		
		/// Processes an options file.
		private static void ProcessOptionsFile(XDocument file) {
			// Resets the values
			booleans.Clear();
			floats.Clear();
			integers.Clear();
			strings.Clear();
			
			// Options
			XElement optionsNode = file.Element(Parameters.XmlNodeOptions);
			
			// Booleans
			foreach (XElement booleanNode in optionsNode.Elements(Parameters.XmlNodeBoolean)) {
				XAttribute idAttribute = booleanNode.Attribute(Parameters.XmlAttributeId);

				string id = Utilities.GetXmlAttributeStringValue(idAttribute);
				bool value = Utilities.GetXmlNodeBooleanValue(booleanNode);
				
				booleans.Add(id, value);
			}
			
			// Floats
			foreach (XElement floatNode in optionsNode.Elements(Parameters.XmlNodeFloat)) {
				XAttribute idAttribute = floatNode.Attribute(Parameters.XmlAttributeId);

				string id = Utilities.GetXmlAttributeStringValue(idAttribute);
				float value = Utilities.GetXmlNodeFloatValue(floatNode);
				
				floats.Add(id, value);
			}
			
			// Integers
			foreach (XElement integerNode in optionsNode.Elements(Parameters.XmlNodeInteger)) {
				XAttribute idAttribute = integerNode.Attribute(Parameters.XmlAttributeId);

				string id = Utilities.GetXmlAttributeStringValue(idAttribute);
				int value = Utilities.GetXmlNodeIntegerValue(integerNode);
				
				integers.Add(id, value);
			}
			
			// Strings
			foreach (XElement stringNode in optionsNode.Elements(Parameters.XmlNodeString)) {
				XAttribute idAttribute = stringNode.Attribute(Parameters.XmlAttributeId);

				string id = Utilities.GetXmlAttributeStringValue(idAttribute);
				string value = Utilities.GetXmlNodeStringValue(stringNode);
				
				strings.Add(id, value);
			}
		}

	}
	
}
