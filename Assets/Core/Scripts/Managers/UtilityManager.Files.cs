using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using UnityEngine;

namespace SaguFramework {
	
	public static partial class UtilityManager {

		private static Encoding encoding;

		public static FileInfo[] GetDirectoryFiles(string directoryPath, string fileExtension) {
			// TODO: errors, exceptions?
			
			// Translates environment variables into actual paths
			directoryPath = Environment.ExpandEnvironmentVariables(directoryPath);

			// Initializes the directory's handler
			DirectoryInfo directory = new DirectoryInfo(directoryPath);

			// Gets the directory files that match the file extension
			FileInfo[] directoryFiles = directory.GetFiles("*" + fileExtension);
			
			return directoryFiles;
		}
		
		public static string GetDirectoryPath(params string[] directoryPaths) {
			// Initializes the path
			string path = "";
			
			// Appends the directory paths
			for (int i = 0; i < directoryPaths.Length - 1; i++) {
				path += directoryPaths[i];
				path += Path.DirectorySeparatorChar;
			}
			path += directoryPaths[directoryPaths.Length - 1];
			
			return path;
		}
		
		public static string GetDirectoryResourcePath(params string[] directoryPaths) {
			// Initializes the resource path
			string resourcePath = "";
			
			// Appends the directory paths
			for (int i = 0; i < directoryPaths.Length - 1; i++) {
				resourcePath += directoryPaths[i];
				resourcePath += "/"; // All asset names and paths in Unity use forward slashes
			}
			resourcePath += directoryPaths[directoryPaths.Length - 1];
			
			return resourcePath;
		}

		public static string GetFileNameWithoutExtension(FileInfo file) {
			// Gets the file's name
			string fileName = file.Name;

			// Gets the file's name without extension and returns it
			return Path.GetFileNameWithoutExtension(fileName);
		}

		public static string GetFilePath(string fileName, string fileExtension, params string[] directoryPaths) {
			// Initializes the path
			string path = "";

			// Appends the directory paths
			foreach (string directoryPath in directoryPaths) {
				path += directoryPath;
				path += Path.DirectorySeparatorChar;
			}

			// Appends the file's name and extension
			path += fileName;
			path += fileExtension;
			
			return path;
		}

		public static string GetFileResourcePath(string fileName, params string[] directoryPaths) {
			// Initializes the resource path
			string resourcePath = "";
			
			// Appends the directory paths
			foreach (string directoryPath in directoryPaths) {
				resourcePath += directoryPath;
				resourcePath += "/"; // All asset names and paths in Unity use forward slashes
			}
			
			// Appends the file's name
			resourcePath += fileName;
			
			return resourcePath;
		}

		public static bool GetXmlNodeBooleanValue(XElement node) {
			// Gets the node's string value
			string stringValue = GetXmlNodeStringValue(node);

			// Parses the boolean value and returns it
			return System.Boolean.Parse(stringValue);
		}
		
		public static float GetXmlNodeFloatValue(XElement node) {
			// Gets the node's string value
			string stringValue = GetXmlNodeStringValue(node);

			// Parses the float value and returns it
			return float.Parse(stringValue, CultureInfo.InvariantCulture);
		}
		
		public static int GetXmlNodeIntegerValue(XElement node) {
			// Gets the node's string value
			string stringValue = GetXmlNodeStringValue(node);

			// Parses the integer value and returns it
			return int.Parse(stringValue, CultureInfo.InvariantCulture);
		}

		public static Location GetXmlNodeLocationValue(XElement node) {
			// Gets the position in game and the room's ID
			XElement positionInGameNode = node.Element(ParameterManager.XmlTagPositionInGame);
			Vector2 positionInGame = UtilityManager.GetXmlNodeVector2Value(positionInGameNode);
			XElement roomIdNode = node.Element(ParameterManager.XmlTagRoomId);
			string roomId = UtilityManager.GetXmlNodeStringValue(roomIdNode);

			// Initializes the location and returns it
			return new Location(positionInGame, roomId);
		}
		
		public static string GetXmlNodeStringValue(XElement node) {
			// Trims the string value and returns it
			return node.Value.Trim();
		}

		public static Vector2 GetXmlNodeVector2Value(XElement node) {
			// Gets the X and Y coordinates
			XElement xNode = node.Element(ParameterManager.XmlTagX);
			float x = UtilityManager.GetXmlNodeFloatValue(xNode);
			XElement yNode = node.Element(ParameterManager.XmlTagY);
			float y = UtilityManager.GetXmlNodeFloatValue(yNode);

			// Initializes the vector and returns it
			return new Vector2(x, y);
		}

		public static FileInfo[] OrderFilesByLastWriteTimeDescending(FileInfo[] files) {
			// Orders the files into a new array and returns it
			return files.OrderByDescending(value => value.LastWriteTime).ToArray();
		}

		public static XDocument ReadResourceXmlFile(string resourcePath) {
			// Loads the resource
			TextAsset textAsset = Resources.Load<TextAsset>(resourcePath);

			// Reads all the text's content and parses it
			string xmlFileContent = textAsset.text;
			XDocument xmlFile = XDocument.Parse(xmlFileContent);
			
			return xmlFile;
		}

		public static XDocument ReadXmlFile(string path) {
			// TODO: errors, exceptions?

			// Translates environment variables into actual paths
			path = Environment.ExpandEnvironmentVariables(path);

			// Reads all the text's content and parses it
			string xmlFileContent = File.ReadAllText(path, encoding);
			XDocument xmlFile = XDocument.Parse(xmlFileContent);
			
			return xmlFile;
		}
		
		public static void SetXmlNodeBooleanValue(XElement node, bool value) {
			// Converts the boolean value to string
			string stringValue = value.ToString();
			
			// Sets the node's string value
			SetXmlNodeStringValue(node, stringValue);
		}
		
		public static void SetXmlNodeFloatValue(XElement node, float value) {
			// Converts the float value to string
			string stringValue = value.ToString(CultureInfo.InvariantCulture);
			
			// Sets the node's string value
			SetXmlNodeStringValue(node, stringValue);
		}
		
		public static void SetXmlNodeIntegerValue(XElement node, int value) {
			// Converts the integer value to string
			string stringValue = value.ToString(CultureInfo.InvariantCulture);

			// Sets the node's string value
			SetXmlNodeStringValue(node, stringValue);
		}
		
		public static void SetXmlNodeLocationValue(XElement node, Location value) {
			// Initializes the position in game and room's ID nodes and sets its values
			XElement positionInGameNode = new XElement(ParameterManager.XmlTagPositionInGame);
			SetXmlNodeVector2Value(positionInGameNode, value.GetPositionInGame());
			XElement roomIdNode = new XElement(ParameterManager.XmlTagRoomId);
			SetXmlNodeStringValue(roomIdNode, value.GetRoomId());
			
			// Adds the position in game and room's ID nodes as node's children
			node.Add(positionInGameNode, roomIdNode);
		}
		
		public static void SetXmlNodeStringValue(XElement node, string value) {
			// Trims the string value and sets it
			node.Value = value.Trim();
		}
		
		public static void SetXmlNodeVector2Value(XElement node, Vector2 value) {
			// Initializes the X and Y nodes and sets its values
			XElement xNode = new XElement(ParameterManager.XmlTagX);
			SetXmlNodeFloatValue(xNode, value.x);
			XElement yNode = new XElement(ParameterManager.XmlTagY);
			SetXmlNodeFloatValue(yNode, value.y);

			// Adds the X and Y nodes as node's children
			node.Add(xNode, yNode);
		}

		public static void WriteXmlFile(string path, XDocument xmlFile) {
			// TODO: errors, exceptions?

			// Translates environment variables into actual paths
			path = Environment.ExpandEnvironmentVariables(path);

			// Initializes the XML writer's settings
			XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
			xmlWriterSettings.Encoding = encoding;
			xmlWriterSettings.Indent = true;
			xmlWriterSettings.IndentChars = "\t";
			xmlWriterSettings.NewLineChars = Environment.NewLine;
			xmlWriterSettings.NewLineHandling = NewLineHandling.None;

			// Creates the non-existent path's directories of the path
			string directoryPath = Path.GetDirectoryName(path);
			Directory.CreateDirectory(directoryPath);

			// Writes the file
			using (XmlWriter xmlWriter = XmlWriter.Create(path, xmlWriterSettings))
				xmlFile.Save(xmlWriter);
		}

	}

}
