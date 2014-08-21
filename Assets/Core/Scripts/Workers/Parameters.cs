using UnityEngine;

public partial class Parameters : MonoBehaviour {

	// TODO: order
	
	public string OptionsFilePath;
	public string StateFilesDirectoryPath;

	public string LanguageOptionId;

	public string MainMenuId;

	public string MainSplashScreenId;

	public string RoomSplashScreenGroupId;


	public void Awake() {
		instance = this;
	}

}
