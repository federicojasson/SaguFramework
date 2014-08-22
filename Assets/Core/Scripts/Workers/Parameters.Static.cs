using UnityEngine;

public partial class Parameters : MonoBehaviour {
	
	private static Parameters instance; // Singleton instance
	
	public static float GetGameScreenAspectRatio() {
		return instance.GameScreenAspectRatio;
	}

	public static string GetOptionsFilePath() {
		return instance.OptionsFilePath;
	}

	public static int GetPixelsPerUnit() {
		return instance.PixelsPerUnit;
	}

	public static string GetStateFilesDirectoryPath() {
		return instance.StateFilesDirectoryPath;
	}

}
