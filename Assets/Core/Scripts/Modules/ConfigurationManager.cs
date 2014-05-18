using System;
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
			ErrorManager.Terminate("ConfigurationManager", "The configuration \"" + id + "\" was not found");
		
		return configuration;
	}

	public static void LoadConfigurations() {
		// Discards all current configurations
		configurations.Clear();

		TextAsset textAsset = (TextAsset) Resources.Load(C.FILE_PATH_CONFIGURATIONS, typeof(TextAsset));
		if (textAsset == null)
			// The configurations file was not found
			ErrorManager.Terminate("ConfigurationManager", "The configurations file was not found");

		try {
			XElement root = XDocument.Parse(textAsset.text).Root;

			foreach (XElement node in root.Elements())
				if (node.Name.LocalName.Equals(C.CONFIGURATION_TAG)) {
					string key = node.Attribute(C.CONFIGURATION_ATTRIBUTE_ID).Value.Trim();
					string value = node.Value.Trim();
					configurations.Add(key, value);
				}
		} catch (Exception exception) {
			// The configurations file couldn't be parsed
			ErrorManager.Terminate("ConfigurationManager", "The configurations file couldn't be parsed");
		}
	}

}
