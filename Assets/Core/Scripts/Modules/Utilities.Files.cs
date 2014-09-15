using System;
using System.Globalization;
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

		public static bool GetXmlNodeBooleanValue(XElement node) {
			string value = GetXmlNodeStringValue(node);
			return Boolean.Parse(value);
		}
		
		public static CharacterState GetXmlNodeCharacterStateValue(XElement node) {
			XElement directionNode = node.Element(Parameters.XmlTagDirection);
			Direction direction = GetXmlNodeDirectionValue(directionNode);
			XElement locationNode = node.Element(Parameters.XmlTagLocation);
			Location location = GetXmlNodeLocationValue(locationNode);

			return new CharacterState(direction, location);
		}
		
		public static Direction GetXmlNodeDirectionValue(XElement node) {
			string value = GetXmlNodeStringValue(node);
			
			if (value == Parameters.DirectionLeft)
				return Direction.Left;
			else
				return Direction.Right;
		}
		
		public static float GetXmlNodeFloatValue(XElement node) {
			string value = GetXmlNodeStringValue(node);
			return float.Parse(value, CultureInfo.InvariantCulture);
		}
		
		public static int GetXmlNodeIntegerValue(XElement node) {
			string value = GetXmlNodeStringValue(node);
			return int.Parse(value, CultureInfo.InvariantCulture);
		}
		
		public static ItemState GetXmlNodeItemStateValue(XElement node) {
			XElement locationNode = node.Element(Parameters.XmlTagLocation);
			Location location = GetXmlNodeLocationValue(locationNode);
			
			return new ItemState(location);
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
		
		public static void SetXmlNodeBooleanValue(XElement node, bool value) {
			string stringValue = value.ToString();
			SetXmlNodeStringValue(node, stringValue);
		}
		
		public static void SetXmlNodeCharacterStateValue(XElement node, CharacterState value) {
			XElement directionNode = new XElement(Parameters.XmlTagDirection);
			SetXmlNodeDirectionValue(directionNode, value.GetDirection());
			XElement locationNode = new XElement(Parameters.XmlTagLocation);
			SetXmlNodeLocationValue(locationNode, value.GetLocation());
			
			node.Add(directionNode, locationNode);
		}
		
		public static void SetXmlNodeDirectionValue(XElement node, Direction value) {
			string stringValue;
			
			if (value == Direction.Left)
				stringValue = Parameters.DirectionLeft;
			else
				stringValue = Parameters.DirectionRight;
			
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
		
		public static void SetXmlNodeItemStateValue(XElement node, ItemState value) {
			XElement locationNode = new XElement(Parameters.XmlTagLocation);
			SetXmlNodeLocationValue(locationNode, value.GetLocation());
			
			node.Add(locationNode);
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
