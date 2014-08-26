using UnityEngine;

namespace FrameworkNamespace {

	public class Framework : MonoBehaviour {

		public void Awake() {
			// Prevents this game object from being destroyed when the scene changes
			DontDestroyOnLoad(this);
		}
		
	}

}
