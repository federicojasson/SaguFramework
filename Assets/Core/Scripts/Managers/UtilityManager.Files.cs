using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using UnityEngine;

namespace SaguFramework {
	
	public static partial class UtilityManager {

		private static Encoding encoding;

		public static string GetPath(string directoryPath, string fileName, string fileExtension) {
			// Initializes the path
			string path = "";

			// Appends the components of the path
			path += directoryPath;
			path += Path.DirectorySeparatorChar;
			path += fileName;
			path += fileExtension;
			
			return path;
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

		public static XDocument ReadXmlFile(string path) {
			// TODO: errors, exceptions?

			// Translates environment variables into actual paths
			path = Environment.ExpandEnvironmentVariables(path);

			// Reads all the text's content and parses it
			string xmlFileContent = File.ReadAllText(path, encoding);
			XDocument xmlFile = XDocument.Parse(xmlFileContent);
			
			return xmlFile;
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
			xmlWriterSettings.NewLineChars = System.Environment.NewLine;
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
