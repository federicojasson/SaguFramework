using SaguFramework.Managers;
using UnityEngine;

namespace SaguFramework.Entities {
	
	public class Item : MonoBehaviour {

		public void Awake() {
			// Registers itself with the ObjectManager
			ObjectManager.RegisterItem(this);
		}

		public void OnDestroy() {
			// Unregisters itself from the ObjectManager
			ObjectManager.UnregisterItem(this);
		}

	}
	
}
