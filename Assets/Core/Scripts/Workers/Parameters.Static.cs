using UnityEngine;

public partial class Parameters : MonoBehaviour {
	
	private static Parameters instance; // Singleton instance

	public static string GetLanguageOptionId() {
		return instance.LanguageOptionId;
	}

	public static string GetMainMenuId() {
		return instance.MainMenuId;
	}

	public static string GetMainSplashScreenId() {
		return instance.MainSplashScreenId;
	}

	public static string GetOptionsFilePath() {
		return instance.OptionsFilePath;
	}

	public static string GetRoomSplashScreenGroupId() {
		return instance.RoomSplashScreenGroupId;
	}

	public static string GetStateFilesDirectoryPath() {
		return instance.StateFilesDirectoryPath;
	}

}
