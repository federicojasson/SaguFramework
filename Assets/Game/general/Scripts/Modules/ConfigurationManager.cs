using System.Xml.Linq;
using UnityEngine;

public static class ConfigurationManager {

	private static string languageId;

	public static string GetLanguageId() {
		return languageId;
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
	
}
