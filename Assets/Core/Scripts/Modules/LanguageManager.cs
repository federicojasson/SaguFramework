using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public static class LanguageManager {

	private static Dictionary<string, string> texts;

	static LanguageManager() {
		texts = new Dictionary<string, string>();
	}

	public static string GetText(string id) {
		string text;
		if (! texts.TryGetValue(id, out text))
			// The text was not found
			ErrorManager.Terminate("LanguageManager", "A text was not found");

		return text;
	}

	public static void LoadLanguage(string id) {
		// Discards all current texts
		texts.Clear();

		TextAsset textAsset = (TextAsset) Resources.Load(C.FILE_PATH_LANGUAGE_TEXTS(id), typeof(TextAsset));
		if (textAsset == null)
			// The language texts file was not found
			ErrorManager.Terminate("LanguageManager", "The language texts file was not found");

		XElement root = XDocument.Parse(textAsset.text).Root;
		// TODO: what if text can't be parsed? how to detect it? (TRY IT)
		
		// TODO: check errors
		foreach (XElement node in root.Elements())
			if (node.Name.LocalName.Equals(C.TEXT_TAG))
				texts.Add(node.Attribute(C.TEXT_ATTRIBUTE_ID).Value.Trim(), node.Value.Trim());
				// TODO: what if the Key already exists? ArgumentException!!!
	}

}
