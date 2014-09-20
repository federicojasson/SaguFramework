using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using UnityEngine;

namespace SaguFramework {
	
	public static partial class Utilities {

		private static Encoding encoding;

		public static void DeleteFile(string path) {
			path = Environment.ExpandEnvironmentVariables(path);
			File.Delete(path);
		}

		public static FileInfo[] GetDirectoryFiles(string fileExtension, string directoryPath) {
			// TODO: errors, exceptions?

			directoryPath = Environment.ExpandEnvironmentVariables(directoryPath);

			DirectoryInfo directory = new DirectoryInfo(directoryPath);
			FileInfo[] directoryFiles = directory.GetFiles("*" + fileExtension);
			
			return directoryFiles;
		}

		public static string GetDirectoryPath(params string[] directoryPaths) {
			string path = string.Empty;

			for (int i = 0; i < directoryPaths.Length - 1; i++) {
				path += directoryPaths[i];
				path += Path.DirectorySeparatorChar;
			}
			path += directoryPaths[directoryPaths.Length - 1];
			
			return path;
		}

		public static string GetFileNameWithoutExtension(FileInfo file) {
			return Path.GetFileNameWithoutExtension(file.Name);
		}

		public static string GetFilePath(string fileName, string fileExtension, params string[] directoryPaths) {
			string path = string.Empty;
			
			foreach (string directoryPath in directoryPaths) {
				path += directoryPath;
				path += Path.DirectorySeparatorChar;
			}
			
			path += fileName;
			path += fileExtension;
			
			return path;
		}

		public static string GetFileResourcePath(string fileName, params string[] directoryPaths) {
			string resourcePath = string.Empty;
			
			foreach (string directoryPath in directoryPaths) {
				resourcePath += directoryPath;
				resourcePath += "/"; // All asset names and paths in Unity use forward slashes
			}
			
			resourcePath += fileName;
			
			return resourcePath;
		}

		public static bool GetXmlAttributeBooleanValue(XAttribute attribute) {
			string value = GetXmlAttributeStringValue(attribute);
			return StringToBoolean(value);
		}

		public static float GetXmlAttributeFloatValue(XAttribute attribute) {
			string value = GetXmlAttributeStringValue(attribute);
			return StringToFloat(value);
		}
		
		public static int GetXmlAttributeIntegerValue(XAttribute attribute) {
			string value = GetXmlAttributeStringValue(attribute);
			return StringToInteger(value);
		}

		public static string GetXmlAttributeStringValue(XAttribute attribute) {
			return attribute.Value.Trim();
		}

		public static bool GetXmlNodeBooleanValue(XElement node) {
			string value = GetXmlNodeStringValue(node);
			return StringToBoolean(value);
		}
		
		public static float GetXmlNodeFloatValue(XElement node) {
			string value = GetXmlNodeStringValue(node);
			return StringToFloat(value);
		}
		
		public static int GetXmlNodeIntegerValue(XElement node) {
			string value = GetXmlNodeStringValue(node);
			return StringToInteger(value);
		}
		
		public static string GetXmlNodeStringValue(XElement node) {
			return node.Value.Trim();
		}

		public static FileInfo[] OrderFilesByLastWriteTimeDescending(FileInfo[] files) {
			return files.OrderByDescending(value => value.LastWriteTime).ToArray();
		}
		
		public static XDocument ReadResourceXmlFile(string resourcePath) {
			TextAsset textAsset = Resources.Load<TextAsset>(resourcePath);
			
			string xmlFileContent = textAsset.text;
			XDocument xmlFile = XDocument.Parse(xmlFileContent);
			
			return xmlFile;
		}
		
		public static XDocument ReadXmlFile(string path) {
			// TODO: errors, exceptions?
			
			path = Environment.ExpandEnvironmentVariables(path);
			
			string xmlFileContent = File.ReadAllText(path, encoding);
			XDocument xmlFile = XDocument.Parse(xmlFileContent);
			
			return xmlFile;
		}

		public static void SetXmlAttributeBooleanValue(XAttribute attribute, bool value) {
			SetXmlAttributeStringValue(attribute, BooleanToString(value));
		}
		
		public static void SetXmlAttributeFloatValue(XAttribute attribute, float value) {
			SetXmlAttributeStringValue(attribute, FloatToString(value));
		}
		
		public static void SetXmlAttributeIntegerValue(XAttribute attribute, int value) {
			SetXmlAttributeStringValue(attribute, IntegerToString(value));
		}
		
		public static void SetXmlAttributeStringValue(XAttribute attribute, string value) {
			attribute.Value = value.Trim();
		}

		public static void SetXmlNodeBooleanValue(XElement node, bool value) {
			SetXmlNodeStringValue(node, BooleanToString(value));
		}
		
		public static void SetXmlNodeFloatValue(XElement node, float value) {
			SetXmlNodeStringValue(node, FloatToString(value));
		}
		
		public static void SetXmlNodeIntegerValue(XElement node, int value) {
			SetXmlNodeStringValue(node, IntegerToString(value));
		}
		
		public static void SetXmlNodeStringValue(XElement node, string value) {
			node.Value = value.Trim();
		}

		public static void WriteXmlFile(string path, XDocument xmlFile) {
			// TODO: errors, exceptions?
			
			path = Environment.ExpandEnvironmentVariables(path);
			
			XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
			xmlWriterSettings.Encoding = encoding;
			xmlWriterSettings.Indent = true;
			xmlWriterSettings.IndentChars = "\t";
			xmlWriterSettings.NewLineChars = Environment.NewLine;
			xmlWriterSettings.NewLineHandling = NewLineHandling.None;
			
			string directoryPath = Path.GetDirectoryName(path);
			Directory.CreateDirectory(directoryPath);
			
			using (XmlWriter xmlWriter = XmlWriter.Create(path, xmlWriterSettings))
				xmlFile.Save(xmlWriter);
		}

	}
	
}
