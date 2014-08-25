using UnityEngine;

public partial class Parameters : MonoBehaviour {

	// TODO: order
	public float GameScreenAspectRatio = 16f / 9f;

	public string OptionsFilePath = "%USERPROFILE%\\GameName\\Options.xml";
	public string StateFilesDirectoryPath = "%USERPROFILE%\\GameName\\States";


	public void Awake() {
		instance = this;
	}

}
