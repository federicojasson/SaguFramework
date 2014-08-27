using UnityEngine;

namespace SaguFramework {

	public partial class Game : MonoBehaviour {

		public GameParameters GameParameters;

		public void Awake() {
			// Sets itself as the singleton instance
			instance = this;

			// Prevents this object from being destroyed when the scene changes
			DontDestroyOnLoad(this);
		}

	}

}
