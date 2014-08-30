using UnityEngine;

namespace SaguFramework {
	
	public class InputReader : MonoBehaviour {
		
		public void Update() {
			// TODO

			if (Input.GetKeyDown(KeyCode.P))
				GameManager.OpenMenu("PauseMenu");
		}
		
	}
	
}
