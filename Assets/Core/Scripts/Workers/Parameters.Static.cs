using UnityEngine;

public partial class Parameters : MonoBehaviour {
	
	private static Parameters instance; // Singleton instance

	public static string GetStateFilesDirectoryPath() {
		return instance.StateFilesDirectoryPath;
	}

}
