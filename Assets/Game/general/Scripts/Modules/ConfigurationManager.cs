using System.Xml.Linq;
using UnityEngine;

public static class ConfigurationManager {

	private static string languageId;

	public static string GetLanguageId() {
		return languageId;
	}

	// TODO: some outsider should invoke this method
	public static void SetLanguageId(string languageId) {
		ConfigurationManager.languageId = languageId;
	}

	public static void LoadConfigurations() {
		TextAsset textAsset = (TextAsset) Resources.Load(P.FILE_PATH_CONFIGURATIONS, typeof(TextAsset));
		XElement root = XDocument.Parse(textAsset.text).Root;

		foreach (XElement node in root.Elements())
			switch (node.Name.LocalName) {
				case "language-id" : {
					languageId = node.Value.Trim();
					break;
				}
			}
	}

	// TODO: some outsider should invoke this method
	public static void SaveConfigurations() {
		// TODO: rewrite Configurations.xml according to current configurations
	}
	
}
