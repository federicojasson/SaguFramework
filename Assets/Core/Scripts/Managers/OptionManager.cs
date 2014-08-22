using System;
using System.Collections.Generic;
using System.Xml.Linq;

public static class OptionManager {

	//private static Dictionary<string, string> options;
	private static Dictionary<string, bool> booleans;
	private static Dictionary<string, float> floats;
	private static Dictionary<string, int> integers;
	private static Dictionary<string, string> strings;

	static OptionManager() {
		booleans = new Dictionary<string, bool>();
		floats = new Dictionary<string, float>();
		integers = new Dictionary<string, int>();
		strings = new Dictionary<string, string>();
	}

	public static bool GetBoolean(string id) {
		return booleans[id];
	}

	public static float GetFloat(string id) {
		return floats[id];
	}

	public static int GetInteger(string id) {
		return integers[id];
	}

	public static string GetString(string id) {
		return strings[id];
	}
	
	public static void LoadOptions() {
		try {
			string path = Parameters.GetOptionsFilePath();
			XDocument optionsFile = FileManager.ReadXmlFile(path);
			LoadOptionsFile(optionsFile);
		} catch (Exception) {
			string resourcePath = Parameters.InitialOptionsFileResourcePath;
			XDocument optionsFile = FileManager.ReadResourceXmlFile(resourcePath);
			LoadOptionsFile(optionsFile);
			SaveOptions();
		}
	}

	public static void SaveOptions() {
		XElement root = new XElement(Parameters.XmlTagOptions);

		foreach (KeyValuePair<string, bool> entry in booleans) {
			XElement idNode = new XElement(Parameters.XmlTagId, entry.Key.Trim());
			XElement valueNode = new XElement(Parameters.XmlTagValue, UtilityManager.BooleanToString(entry.Value));
			XElement booleanNode = new XElement(Parameters.XmlTagBoolean, idNode, valueNode);
			root.Add(booleanNode);
		}

		foreach (KeyValuePair<string, float> entry in floats) {
			XElement idNode = new XElement(Parameters.XmlTagId, entry.Key.Trim());
			XElement valueNode = new XElement(Parameters.XmlTagValue, UtilityManager.FloatToString(entry.Value));
			XElement floatNode = new XElement(Parameters.XmlTagFloat, idNode, valueNode);
			root.Add(floatNode);
		}
		
		foreach (KeyValuePair<string, int> entry in integers) {
			XElement idNode = new XElement(Parameters.XmlTagId, entry.Key.Trim());
			XElement valueNode = new XElement(Parameters.XmlTagValue, UtilityManager.IntegerToString(entry.Value));
			XElement integerNode = new XElement(Parameters.XmlTagInteger, idNode, valueNode);
			root.Add(integerNode);
		}

		foreach (KeyValuePair<string, string> entry in strings) {
			XElement idNode = new XElement(Parameters.XmlTagId, entry.Key.Trim());
			XElement valueNode = new XElement(Parameters.XmlTagValue, entry.Value.Trim());
			XElement stringNode = new XElement(Parameters.XmlTagString, idNode, valueNode);
			root.Add(stringNode);
		}
		
		XDocument optionsFile = new XDocument(root);
		FileManager.WriteXmlFile(Parameters.GetOptionsFilePath(), optionsFile);
	}

	public static void SetBoolean(string id, bool value) {
		booleans[id] = value;
	}
	
	public static void SetFloat(string id, float value) {
		floats[id] = value;
	}
	
	public static void SetInteger(string id, int value) {
		integers[id] = value;
	}
	
	public static void SetString(string id, string value) {
		strings[id] = value;
	}

	// TODO: refactor XML handling

	private static void LoadOptionsFile(XDocument optionsFile) {
		booleans.Clear();
		floats.Clear();
		integers.Clear();
		strings.Clear();

		XElement root = optionsFile.Root;

		foreach (XElement node in root.Elements(Parameters.XmlTagBoolean)) {
			string id = node.Element(Parameters.XmlTagId).Value.Trim();
			string value = node.Element(Parameters.XmlTagValue).Value.Trim();

			bool booleanValue = UtilityManager.StringToBoolean(value);

			booleans.Add(id, booleanValue);
		}

		foreach (XElement node in root.Elements(Parameters.XmlTagFloat)) {
			string id = node.Element(Parameters.XmlTagId).Value.Trim();
			string value = node.Element(Parameters.XmlTagValue).Value.Trim();

			float floatValue = UtilityManager.StringToFloat(value);
			
			floats.Add(id, floatValue);
		}
		
		foreach (XElement node in root.Elements(Parameters.XmlTagInteger)) {
			string id = node.Element(Parameters.XmlTagId).Value.Trim();
			string value = node.Element(Parameters.XmlTagValue).Value.Trim();

			int integerValue = UtilityManager.StringToInteger(value);
			
			integers.Add(id, integerValue);
		}
		
		foreach (XElement node in root.Elements(Parameters.XmlTagString)) {
			string id = node.Element(Parameters.XmlTagId).Value.Trim();
			string value = node.Element(Parameters.XmlTagValue).Value.Trim();
			
			strings.Add(id, value);
		}
	}

}
