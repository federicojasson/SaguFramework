using System.Collections.Generic;
using System.Text;
using System.Xml;
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

	public static void LoadInitialOptions() {
		string resourcePath = Parameters.InitialOptionsFileResourcePath;
		string optionsFileContent = UtilityManager.ReadResourceTextFileContent(resourcePath);
		LoadOptionsFile(optionsFileContent);
	}
	
	public static void LoadOptions() {
		// TODO
	}

	public static void SaveOptions() {
		XElement root = new XElement("options"); // TODO: use parameters?

		foreach (KeyValuePair<string, string> entry in options)
			root.Add(new XElement(entry.Key.Trim(), entry.Value.Trim()));

		XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
		xmlWriterSettings.Indent = true;
		xmlWriterSettings.IndentChars = "\t";
		xmlWriterSettings.NewLineChars = System.Environment.NewLine;
		xmlWriterSettings.NewLineHandling = NewLineHandling.None;

		using (XmlWriter xmlWriter = XmlWriter.Create(Parameters.GetOptionsFilePath(), xmlWriterSettings))
			root.Save(xmlWriter);
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
	
	private static void LoadOptionsFile(string optionsFileContent) {
		// Clears the options
		options.Clear();

		XElement root = XElement.Parse(optionsFileContent);

		foreach (XElement node in root.Elements()) {
			string key = node.Name.LocalName.Trim();
			string value = node.Value.Trim();
			options.Add(key, value);
		}
	}

}
