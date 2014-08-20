using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

public static class StateManager {

	public static string[] GetStateIds() {
		// Gets the state files
		FileInfo[] stateFiles = FileManager.GetDirectoryFiles(Parameters.GetStateFilesDirectoryPath(), Parameters.StateFilesExtension);

		// TODO: maybe do something else in FileManager

		// Orders the state files by last write time (in descending order)
		FileInfo[] orderedStateFiles = stateFiles.OrderByDescending(value => value.LastWriteTime).ToArray();

		// Gets the state IDs
		string[] stateIds = new string[orderedStateFiles.Length];
		for (int i = 0; i < orderedStateFiles.Length; i++)
			stateIds[i] = Path.GetFileNameWithoutExtension(orderedStateFiles[i].Name);
		
		return stateIds;
	}

	public static void LoadInitialState() {
		string resourcePath = Parameters.InitialStateFileResourcePath;
		XDocument stateFile = FileManager.ReadResourceXmlFile(resourcePath);
		LoadStateFile(stateFile);
	}

	public static bool LoadState(string id) {
		try {
			string path = GetStateFilePath(id);
			XDocument stateFile = FileManager.ReadXmlFile(path);
			LoadStateFile(stateFile);

			return true;
		} catch (Exception) {
			return false;
		}
	}

	public static void SaveState(string id) {
		XElement root = new XElement("state"); // TODO: use parameters?

		// TODO: fill root
		
		XDocument stateFile = new XDocument(root);
		string path = GetStateFilePath(id);
		FileManager.WriteXmlFile(path, stateFile);
	}

	private static string GetStateFilePath(string id) {
		// TODO: maybe do something else in FileManager

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

		// TODO
	}

}
