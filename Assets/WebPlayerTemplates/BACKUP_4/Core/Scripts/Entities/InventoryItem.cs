using UnityEngine;

namespace SaguFramework {
	
	public class InventoryItem : MonoBehaviour {
		
		private InventoryItemBehaviour behaviour;

		public void Awake() {
			// Registers itself with the ObjectManager
			ObjectManager.RegisterInventoryItem(this);
			
			// Hides the inventory item initially
			Hide();
		}
		
		public void Hide() {
			// Deactivates the object in order to make the inventory item invisible
			gameObject.SetActive(false);
		}

		public void OnDestroy() {
			// Unregisters itself from the ObjectManager
			ObjectManager.UnregisterInventoryItem(this);
		}
		
		public void SetBehaviour(InventoryItemBehaviour behaviour) {
			this.behaviour = behaviour;
		}
		
		public void Show() {
			// Activates the object in order to make the menu visible
			gameObject.SetActive(true);
		}

	}
	
}
