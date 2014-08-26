using UnityEngine;

namespace FrameworkNamespace {

	public partial class Parameters : MonoBehaviour {

		// TODO: order
		public float GameAspectRatio = 16f / 9f;

		public string OptionsFilePath = "%USERPROFILE%\\GameName\\Options.xml";
		public string StateFilesDirectoryPath = "%USERPROFILE%\\GameName\\States";


		public void Awake() {
			instance = this;
		}

	}

}
