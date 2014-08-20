using System;
using System.Collections.Generic;
using System.Xml.Linq;

public static class OptionManager {

	private static Dictionary<string, string> options;

	static OptionManager() {
		options = new Dictionary<string, string>();
	}

	public static bool GetBool(string id) {
		return UtilityManager.StringToBool(options[id]);
	}

	public static float GetFloat(string id) {
		return UtilityManager.StringToFloat(options[id]);
	}

	public static int GetInt(string id) {
		return UtilityManager.StringToInt(options[id]);
	}

	public static string GetString(string id) {
		return options[id];
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

		foreach (KeyValuePair<string, string> entry in options)
			root.Add(new XElement(entry.Key.Trim(), entry.Value.Trim()));
		
		XDocument optionsFile = new XDocument(root);
		FileManager.WriteXmlFile(Parameters.GetOptionsFilePath(), optionsFile);
	}

	public static void SetBool(string id, bool value) {
		options[id] = UtilityManager.BoolToString(value);
	}
	
	public static void SetFloat(string id, float value) {
		options[id] = UtilityManager.FloatToString(value);
	}
	
	public static void SetInt(string id, int value) {
		options[id] = UtilityManager.IntToString(value);
	}
	
	public static void SetString(string id, string value) {
		options[id] = value;
	}
	
	private static void LoadOptionsFile(XDocument optionsFile) {
		// Clears the options
		options.Clear();

		XElement root = optionsFile.Root;

		foreach (XElement node in root.Elements()) {
			string key = node.Name.LocalName.Trim();
			string value = node.Value.Trim();
			options.Add(key, value);
		}
	}

}
