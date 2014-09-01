using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace SaguFramework {
	
	public static partial class OptionManager {
		
		public static void LoadOptions() {
			try {
				// Gets the options file's path
				string path = ParameterManager.GetOptionsFilePath();

				// Reads the options file
				XDocument optionsFile = UtilityManager.ReadXmlFile(path);

				// Processes the options file
				ProcessOptionsFile(optionsFile);
			} catch (Exception) {
				// There was a problem reading or processing the options file

				// Gets the initial options file's resource path
				string resourcePath = ParameterManager.InitialOptionsFileResourcePath;

				// Reads the options file
				XDocument optionsFile = UtilityManager.ReadResourceXmlFile(resourcePath);
				
				// Processes the options file
				ProcessOptionsFile(optionsFile);

				// Saves the options
				SaveOptions();
			}
		}

		public static void SaveOptions() {
			// Generates the options file
			XDocument optionsFile = GenerateOptionsFile();

			// Gets the options file's path
			string path = ParameterManager.GetOptionsFilePath();
			
			// Writes the options file
			UtilityManager.WriteXmlFile(path, optionsFile);
		}

		private static XDocument GenerateOptionsFile() {
			// Options
			XElement optionsNode = new XElement(ParameterManager.XmlTagOptions);

			// Booleans
			foreach (KeyValuePair<string, bool> entry in booleans) {
				XElement booleanNode = new XElement(ParameterManager.XmlTagBoolean);
				
				// Sets the boolean's ID
				XElement booleanIdNode = new XElement(ParameterManager.XmlTagId);
				UtilityManager.SetXmlNodeStringValue(booleanIdNode, entry.Key);
				
				// Sets the boolean's value
				XElement booleanValueNode = new XElement(ParameterManager.XmlTagValue);
				UtilityManager.SetXmlNodeBooleanValue(booleanValueNode, entry.Value);
				
				// Connects the nodes
				booleanNode.Add(booleanIdNode, booleanValueNode);
				optionsNode.Add(booleanNode);
			}

			// Floats
			foreach (KeyValuePair<string, float> entry in floats) {
				XElement floatNode = new XElement(ParameterManager.XmlTagFloat);
				
				// Sets the float's ID
				XElement floatIdNode = new XElement(ParameterManager.XmlTagId);
				UtilityManager.SetXmlNodeStringValue(floatIdNode, entry.Key);
				
				// Sets the float's value
				XElement floatValueNode = new XElement(ParameterManager.XmlTagValue);
				UtilityManager.SetXmlNodeFloatValue(floatValueNode, entry.Value);

				// Connects the nodes
				floatNode.Add(floatIdNode, floatValueNode);
				optionsNode.Add(floatNode);
			}

			// Integers
			foreach (KeyValuePair<string, int> entry in integers) {
				XElement integerNode = new XElement(ParameterManager.XmlTagInteger);
				
				// Sets the integer's ID
				XElement integerIdNode = new XElement(ParameterManager.XmlTagId);
				UtilityManager.SetXmlNodeStringValue(integerIdNode, entry.Key);
				
				// Sets the integer's value
				XElement integerValueNode = new XElement(ParameterManager.XmlTagValue);
				UtilityManager.SetXmlNodeIntegerValue(integerValueNode, entry.Value);
				
				// Connects the nodes
				integerNode.Add(integerIdNode, integerValueNode);
				optionsNode.Add(integerNode);
			}

			// Strings
			foreach (KeyValuePair<string, string> entry in strings) {
				XElement stringNode = new XElement(ParameterManager.XmlTagString);
				
				// Sets the string's ID
				XElement stringIdNode = new XElement(ParameterManager.XmlTagId);
				UtilityManager.SetXmlNodeStringValue(stringIdNode, entry.Key);
				
				// Sets the string's value
				XElement stringValueNode = new XElement(ParameterManager.XmlTagValue);
				UtilityManager.SetXmlNodeStringValue(stringValueNode, entry.Value);

				// Connects the nodes
				stringNode.Add(stringIdNode, stringValueNode);
				optionsNode.Add(stringNode);
			}

			// Initializes and returns the options file
			return new XDocument(optionsNode);
		}
		
		private static void ProcessOptionsFile(XDocument optionsFile) {
			// Clears the data structures
			booleans.Clear();
			floats.Clear();
			integers.Clear();
			strings.Clear();

			// Options
			XElement optionsNode = optionsFile.Element(ParameterManager.XmlTagOptions);

			// Booleans
			foreach (XElement booleanNode in optionsNode.Elements(ParameterManager.XmlTagBoolean)) {
				XElement booleanIdNode = booleanNode.Element(ParameterManager.XmlTagId);
				string booleanId = UtilityManager.GetXmlNodeStringValue(booleanIdNode);
				XElement booleanValueNode = booleanNode.Element(ParameterManager.XmlTagValue);
				bool booleanValue = UtilityManager.GetXmlNodeBooleanValue(booleanValueNode);
				
				// Adds the boolean to the corresponding data structure
				booleans.Add(booleanId, booleanValue);
			}

			// Floats
			foreach (XElement floatNode in optionsNode.Elements(ParameterManager.XmlTagFloat)) {
				XElement floatIdNode = floatNode.Element(ParameterManager.XmlTagId);
				string floatId = UtilityManager.GetXmlNodeStringValue(floatIdNode);
				XElement floatValueNode = floatNode.Element(ParameterManager.XmlTagValue);
				float floatValue = UtilityManager.GetXmlNodeFloatValue(floatValueNode);
				
				// Adds the float to the corresponding data structure
				floats.Add(floatId, floatValue);
			}

			// Integers
			foreach (XElement integerNode in optionsNode.Elements(ParameterManager.XmlTagInteger)) {
				XElement integerIdNode = integerNode.Element(ParameterManager.XmlTagId);
				string integerId = UtilityManager.GetXmlNodeStringValue(integerIdNode);
				XElement integerValueNode = integerNode.Element(ParameterManager.XmlTagValue);
				int integerValue = UtilityManager.GetXmlNodeIntegerValue(integerValueNode);
				
				// Adds the integer to the corresponding data structure
				integers.Add(integerId, integerValue);
			}

			// Strings
			foreach (XElement stringNode in optionsNode.Elements(ParameterManager.XmlTagString)) {
				XElement stringIdNode = stringNode.Element(ParameterManager.XmlTagId);
				string stringId = UtilityManager.GetXmlNodeStringValue(stringIdNode);
				XElement stringValueNode = stringNode.Element(ParameterManager.XmlTagValue);
				string stringValue = UtilityManager.GetXmlNodeStringValue(stringValueNode);
				
				// Adds the string to the corresponding data structure
				strings.Add(stringId, stringValue);
			}
		}
		
	}
	
}
