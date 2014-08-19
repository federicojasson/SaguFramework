using UnityEngine;

public partial class Parameters : MonoBehaviour {
	
	private static Parameters instance; // Singleton instance
	
	public static string GetOptionsFilePath() {
		return instance.OptionsFilePath;
	}

	public static string GetStateFilesDirectoryPath() {
		return instance.StateFilesDirectoryPath;
	}

}
