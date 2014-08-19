using UnityEngine;

public partial class Parameters : MonoBehaviour {

	// TODO: order
	
	public string OptionsFilePath;
	public string StateFilesDirectoryPath;


	public void Awake() {
		instance = this;
	}

}
