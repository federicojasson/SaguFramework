using UnityEngine;

namespace SaguFramework {
	
	public class InventoryItem : MonoBehaviour {

		public void Awake() {
			// Registers itself with the ObjectManager
			ObjectManager.RegisterInventoryItem(this);
		}

		public void OnDestroy() {
			// Unregisters itself from the ObjectManager
			ObjectManager.UnregisterInventoryItem(this);
		}

	}
	
}
