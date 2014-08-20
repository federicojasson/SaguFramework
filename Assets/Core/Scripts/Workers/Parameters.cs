using UnityEngine;

public partial class Parameters : MonoBehaviour {

	// TODO: order
	
	public string OptionsFilePath;
	public string StateFilesDirectoryPath;
	public bool UseSplashScreens;


	public void Awake() {
		instance = this;
	}

}
