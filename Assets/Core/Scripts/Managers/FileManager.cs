using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using UnityEngine;

public static class FileManager {
	
	private static Encoding encoding;

	static FileManager() {
		encoding = new UTF8Encoding(false); // UTF-8 without BOM
	}

	public static FileInfo[] GetDirectoryFiles(string directoryPath, string fileExtension) {
		directoryPath = Environment.ExpandEnvironmentVariables(directoryPath);

		DirectoryInfo directory = new DirectoryInfo(directoryPath);
		FileInfo[] directoryFiles = directory.GetFiles("*" + fileExtension);

		return directoryFiles;
	}

	public static XDocument ReadResourceXmlFile(string resourcePath) {
		TextAsset textAsset = (TextAsset) Resources.Load<TextAsset>(resourcePath);

		string xmlFileContent = textAsset.text;
		XDocument xmlFile = XDocument.Parse(xmlFileContent);

		return xmlFile;
	}

	public static XDocument ReadXmlFile(string path) {
		path = Environment.ExpandEnvironmentVariables(path);

		string xmlFileContent = File.ReadAllText(path, encoding);
		XDocument xmlFile = XDocument.Parse(xmlFileContent);

		return xmlFile;
	}

	public static void WriteXmlFile(string path, XDocument xmlFile) {
		path = Environment.ExpandEnvironmentVariables(path);
		
		XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
		xmlWriterSettings.Encoding = encoding;
		xmlWriterSettings.Indent = true;
		xmlWriterSettings.IndentChars = "\t";
		xmlWriterSettings.NewLineChars = System.Environment.NewLine;
		xmlWriterSettings.NewLineHandling = NewLineHandling.None;

		string directoryPath = Path.GetDirectoryName(path);
		Directory.CreateDirectory(directoryPath);
		using (XmlWriter xmlWriter = XmlWriter.Create(path, xmlWriterSettings))
			xmlFile.Save(xmlWriter);
	}

}
