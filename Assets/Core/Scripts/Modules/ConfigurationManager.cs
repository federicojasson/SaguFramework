using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public static class ConfigurationManager {

	private static Dictionary<string, string> configurations;

	static ConfigurationManager() {
		configurations = new Dictionary<string, string>();
	}

	public static string GetConfiguration(string id) {
		string configuration;
		if (! configurations.TryGetValue(id, out configuration))
			// The configuration was not found
			ErrorManager.Terminate("ConfigurationManager", "A configuration was not found");
		
		return configuration;
	}

	public static void LoadConfigurations() {
		// Discards all current configurations
		configurations.Clear();

		TextAsset textAsset = (TextAsset) Resources.Load(C.FILE_PATH_CONFIGURATIONS, typeof(TextAsset));
		if (textAsset == null)
			// The configurations file was not found
			ErrorManager.Terminate("ConfigurationManager", "The configurations file was not found");

		XElement root = XDocument.Parse(textAsset.text).Root;
		// TODO: what if text can't be parsed? how to detect it? (TRY IT)

		// TODO: check errors
		foreach (XElement node in root.Elements())
			if (node.Name.LocalName.Equals(C.CONFIGURATION_TAG))
				configurations.Add(node.Attribute(C.CONFIGURATION_ATTRIBUTE_ID).Value.Trim(), node.Value.Trim());
				// TODO: what if the Key already exists? ArgumentException!!!
	}

}
