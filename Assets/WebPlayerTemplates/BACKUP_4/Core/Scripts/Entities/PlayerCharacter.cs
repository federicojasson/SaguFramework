using UnityEngine;

namespace SaguFramework {
	
	public class PlayerCharacter : MonoBehaviour {
		
		public void Awake() {
			// Registers itself with the ObjectManager
			ObjectManager.RegisterPlayerCharacter(this);
		}
		
		public void OnDestroy() {
			// Unregisters itself from the ObjectManager
			ObjectManager.UnregisterPlayerCharacter();
		}
		
	}
	
}
