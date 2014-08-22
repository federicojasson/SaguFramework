using System.Xml.Linq;
using UnityEngine;

public static partial class UtilityManager {

	public static XDocument ReadResourceXmlFile(string resourcePath) {
		TextAsset textAsset = UtilityManager.LoadResource<TextAsset>(resourcePath);
		
		string xmlFileContent = textAsset.text;
		XDocument xmlFile = XDocument.Parse(xmlFileContent);
		
		return xmlFile;
	}
	
}
