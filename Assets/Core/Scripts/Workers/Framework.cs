using UnityEngine;

namespace SaguFramework {

	public partial class Framework : MonoBehaviour {

		public FrameworkParameters FrameworkParameters;

		public void Awake() {
			// Sets itself as the singleton instance
			instance = this;
			
			// Prevents this object from being destroyed when the scene changes
			DontDestroyOnLoad(this);
		}

	}

}
