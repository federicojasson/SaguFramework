using UnityEngine;

namespace SaguFramework {

	public class Framework : MonoBehaviour {
		
		public void Awake() {
			// Prevents this object from being destroyed when the scene changes
			DontDestroyOnLoad(this);
		}
		
	}

}
