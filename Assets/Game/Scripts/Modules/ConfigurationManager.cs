using System.Xml.Linq;
using UnityEngine;

public static class ConfigurationManager {

	private static string languageId;

	static ConfigurationManager() {
		// Loads the default configurations
		languageId = "Spanish";
	}

	public static string GetLanguageId() {
		return languageId;
	}

	public static void LoadConfigurations() {
		TextAsset textAsset = (TextAsset) Resources.Load(P.CONFIGURATIONS_FILE_PATH, typeof(TextAsset));
		XElement root = XDocument.Parse(textAsset.text).Root;

		// TODO: maybe use constants for node names
		foreach (XElement node in root.Elements())
			switch (node.Name.LocalName) {
				case "language-id" : {
					languageId = node.Value.Trim();
					break;
				}
			}
	}
	
}
