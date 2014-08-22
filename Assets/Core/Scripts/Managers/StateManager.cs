using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;

public static class StateManager {

	public static string[] GetStateIds() {
		try {
			// Gets the state files
			FileInfo[] stateFiles = UtilityManager.GetDirectoryFiles(Parameters.GetStateFilesDirectoryPath(), Parameters.StateFilesExtension);

			// TODO: maybe do something else in UtilityManager

			// Orders the state files by last write time (in descending order)
			FileInfo[] orderedStateFiles = stateFiles.OrderByDescending(value => value.LastWriteTime).ToArray();

			// Gets the state IDs
			string[] stateIds = new string[orderedStateFiles.Length];
			for (int i = 0; i < orderedStateFiles.Length; i++)
				stateIds[i] = Path.GetFileNameWithoutExtension(orderedStateFiles[i].Name);
			
			return stateIds;
		} catch (Exception) {
			return new string[0];
		}
	}

	public static void LoadInitialState() {
		string resourcePath = Parameters.InitialStateFileResourcePath;
		XDocument stateFile = UtilityManager.ReadResourceXmlFile(resourcePath);
		LoadStateFile(stateFile);
	}

	public static bool LoadState(string id) {
		try {
			string path = GetStateFilePath(id);
			XDocument stateFile = UtilityManager.ReadXmlFile(path);
			LoadStateFile(stateFile);

			return true;
		} catch (Exception) {
			return false;
		}
	}

	public static void SaveState(string id) {
		XElement root = new XElement(Parameters.XmlTagState);

		// TODO: fill root
		
		XDocument stateFile = new XDocument(root);
		string path = GetStateFilePath(id);
		UtilityManager.WriteXmlFile(path, stateFile);
	}

	private static string GetStateFilePath(string id) {
		// TODO: maybe do something else in UtilityManager or Parameters

		string stateFilePath = "";
		stateFilePath += Parameters.GetStateFilesDirectoryPath();
		stateFilePath += Path.DirectorySeparatorChar;
		stateFilePath += id;
		stateFilePath += Parameters.StateFilesExtension;

		return stateFilePath;
	}

	private static void LoadStateFile(XDocument stateFile) {
		// Resets the state managers
		CharacterManager.Reset();
		InventoryManager.Reset();
		ItemManager.Reset();
		RoomManager.Reset();

		XElement root = stateFile.Root;

		{
			string currentRoomId = root.Element(Parameters.XmlTagCurrentRoomId).Value.Trim();

			RoomManager.SetCurrentRoomId(currentRoomId);
		}

		{
			XElement node = root.Element(Parameters.XmlTagPlayerCharacter);
			string id = node.Element(Parameters.XmlTagId).Value.Trim();
			Location location = ReadXmlLocation(node);

			CharacterManager.SetCharacterLocation(id, location);
			CharacterManager.SetPlayerCharacterId(id);
		}

		foreach (XElement node in root.Elements(Parameters.XmlTagCharacter)) {
			string id = node.Element(Parameters.XmlTagId).Value.Trim();
			Location location = ReadXmlLocation(node);

			CharacterManager.SetCharacterLocation(id, location);
		}

		foreach (XElement node in root.Elements(Parameters.XmlTagInventoryItem)) {
			string id = node.Element(Parameters.XmlTagId).Value.Trim();
			// TODO
		}

		foreach (XElement node in root.Elements(Parameters.XmlTagItem)) {
			string id = node.Element(Parameters.XmlTagId).Value.Trim();
			Location location = ReadXmlLocation(node);

			ItemManager.SetItemLocation(id, location);
		}
	}

	// TODO: refactor XML handling

	private static Location ReadXmlLocation(XElement parentNode) {
		XElement node = parentNode.Element(Parameters.XmlTagLocation);
		
		Vector2 position = ReadXmlPosition(node);
		string roomId = node.Element(Parameters.XmlTagRoomId).Value.Trim();
		
		return new Location(position, roomId);
	}

	private static Vector2 ReadXmlPosition(XElement parentNode) {
		XElement node = parentNode.Element(Parameters.XmlTagPosition);

		string x = node.Element(Parameters.XmlTagX).Value.Trim();
		string y = node.Element(Parameters.XmlTagY).Value.Trim();

		float xValue = UtilityManager.StringToFloat(x);
		float yValue = UtilityManager.StringToFloat(y);
		
		return new Vector2(xValue, yValue);
	}

}
