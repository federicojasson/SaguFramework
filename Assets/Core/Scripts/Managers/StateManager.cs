using System.IO;
using System.Linq;

public static class StateManager {

	public static string[] GetStateIds() {
		// Gets the state files directory
		DirectoryInfo directory = new DirectoryInfo(Parameters.GetStateFilesDirectoryPath());

		// Gets the state files
		FileInfo[] stateFiles = directory.GetFiles("*" + Parameters.StateFileExtension);

		// Orders the state files by last write time (in descending order)
		FileInfo[] orderedStateFiles = stateFiles.OrderByDescending(value => value.LastWriteTime).ToArray();

		// Gets the state IDs
		string[] stateIds = new string[orderedStateFiles.Length];
		for (int i = 0; i < orderedStateFiles.Length; i++)
			stateIds[i] = Path.GetFileNameWithoutExtension(orderedStateFiles[i].Name);
		
		return stateIds;
	}

	public static void LoadInitialState() {
		// TODO: carga el estado inicial
	}

	public static void LoadState(string id) {
		// TODO: carga un estado particular
	}

	private static void LoadStateFile(string stateFileContent) {
		// Resets the state managers
		CharacterManager.Reset();
		InventoryManager.Reset();
		ItemManager.Reset();
		RoomManager.Reset();

		// TODO
	}

}
