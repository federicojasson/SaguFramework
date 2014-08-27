using SaguFramework.Behaviours;
using SaguFramework.Managers;
using UnityEngine;

namespace SaguFramework.Entities {
	
	public class Item : MonoBehaviour {

		private ItemBehaviour behaviour; // TODO

		public void Awake() {
			// Registers itself with the ObjectManager
			ObjectManager.RegisterItem(this);
		}

		// TODO: remove this
		public void Start() {
			behaviour.TestMethod();
		}

		public void OnDestroy() {
			// Unregisters itself from the ObjectManager
			ObjectManager.UnregisterItem(this);
		}

		// TODO
		public void SetBehaviour(ItemBehaviour behaviour) {
			this.behaviour = behaviour;
		}

	}
	
}
