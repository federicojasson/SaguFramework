using UnityEngine;

namespace SaguFramework {
	
	public class InputReader : MonoBehaviour {
		
		public void Update() {
			// TODO: just to debug

			if (Input.GetKeyDown(KeyCode.P))
				GameManager.OpenMenu("PauseMenu");

			if (Input.GetKeyDown(KeyCode.M))
				GameManager.OpenMainMenu();
			
			if (Input.GetKeyDown(KeyCode.I))
				GameManager.ShowInventory();
		}
		
	}
	
}
