using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using UnityEngine;

namespace SaguFramework {
	
	public static class Utilities {

		private static Encoding encoding;

		static Utilities() {
			encoding = new UTF8Encoding(false); // UTF-8 without BOM
		}

		public static Color GetColor(Color color, float opacity) {
			return new Color(color.r, color.g, color.b, opacity);
		}

		public static string GetFilePath(string fileName, string fileExtension, params string[] directoryPaths) {
			string path = "";

			foreach (string directoryPath in directoryPaths) {
				path += directoryPath;
				path += Path.DirectorySeparatorChar;
			}

			path += fileName;
			path += fileExtension;
			
			return path;
		}
		
		public static string GetFileResourcePath(string fileName, params string[] directoryPaths) {
			string resourcePath = "";

			foreach (string directoryPath in directoryPaths) {
				resourcePath += directoryPath;
				resourcePath += "/"; // All asset names and paths in Unity use forward slashes
			}

			resourcePath += fileName;
			
			return resourcePath;
		}

		public static Vector3 GetPosition(Vector3 position, float z) {
			return new Vector3(position.x, position.y, z);
		}
		
		public static bool GetXmlNodeBooleanValue(XElement node) {
			string value = GetXmlNodeStringValue(node);
			return Boolean.Parse(value);
		}
		
		public static float GetXmlNodeFloatValue(XElement node) {
			string value = GetXmlNodeStringValue(node);
			return float.Parse(value, CultureInfo.InvariantCulture);
		}
		
		public static int GetXmlNodeIntegerValue(XElement node) {
			string value = GetXmlNodeStringValue(node);
			return int.Parse(value, CultureInfo.InvariantCulture);
		}
		
		public static Location GetXmlNodeLocationValue(XElement node) {
			XElement positionNode = node.Element(Parameters.XmlTagPosition);
			Vector2 position = GetXmlNodeVector2Value(positionNode);
			XElement roomIdNode = node.Element(Parameters.XmlTagRoomId);
			string roomId = GetXmlNodeStringValue(roomIdNode);

			return new Location(position, roomId);
		}
		
		public static string GetXmlNodeStringValue(XElement node) {
			return node.Value.Trim();
		}
		
		public static Vector2 GetXmlNodeVector2Value(XElement node) {
			XElement xNode = node.Element(Parameters.XmlTagX);
			float x = GetXmlNodeFloatValue(xNode);
			XElement yNode = node.Element(Parameters.XmlTagY);
			float y = GetXmlNodeFloatValue(yNode);

			return new Vector2(x, y);
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
		
		public static void SetXmlNodeBooleanValue(XElement node, bool value) {
			string stringValue = value.ToString();
			SetXmlNodeStringValue(node, stringValue);
		}
		
		public static void SetXmlNodeFloatValue(XElement node, float value) {
			string stringValue = value.ToString(CultureInfo.InvariantCulture);
			SetXmlNodeStringValue(node, stringValue);
		}
		
		public static void SetXmlNodeIntegerValue(XElement node, int value) {
			string stringValue = value.ToString(CultureInfo.InvariantCulture);
			SetXmlNodeStringValue(node, stringValue);
		}
		
		public static void SetXmlNodeLocationValue(XElement node, Location value) {
			XElement positionNode = new XElement(Parameters.XmlTagPosition);
			SetXmlNodeVector2Value(positionNode, value.GetPosition());
			XElement roomIdNode = new XElement(Parameters.XmlTagRoomId);
			SetXmlNodeStringValue(roomIdNode, value.GetRoomId());

			node.Add(positionNode, roomIdNode);
		}
		
		public static void SetXmlNodeStringValue(XElement node, string value) {
			node.Value = value.Trim();
		}
		
		public static void SetXmlNodeVector2Value(XElement node, Vector2 value) {
			XElement xNode = new XElement(Parameters.XmlTagX);
			SetXmlNodeFloatValue(xNode, value.x);
			XElement yNode = new XElement(Parameters.XmlTagY);
			SetXmlNodeFloatValue(yNode, value.y);

			node.Add(xNode, yNode);
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
