using UnityEngine;

namespace SaguFramework {
	
	public class Item : MonoBehaviour {

		private ItemBehaviour behaviour;

		public void Awake() {
			// Registers itself with the ObjectManager
			ObjectManager.RegisterItem(this);
		}

		public void OnDestroy() {
			// Unregisters itself from the ObjectManager
			ObjectManager.UnregisterItem(this);
		}

		public void SetBehaviour(ItemBehaviour behaviour) {
			this.behaviour = behaviour;
		}

	}
	
}
