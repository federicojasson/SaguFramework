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
		XElement root = new XElement("options"); // TODO: use parameters?

		// TODO
		/*foreach (KeyValuePair<string, string> entry in options)
			root.Add(new XElement(entry.Key.Trim(), entry.Value.Trim()));*/
		
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
