using UnityEngine;

namespace FrameworkNamespace {

	public partial class FrameworkAssets : MonoBehaviour {

		public GameImage GameImagePrefab;

		public void Awake() {;
			instance = this;
		}
		
	}

}
