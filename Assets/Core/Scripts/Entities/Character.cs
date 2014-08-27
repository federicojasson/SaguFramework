using SaguFramework.Managers;
using UnityEngine;

namespace SaguFramework.Entities {

	public class Character : MonoBehaviour {

		public void Awake() {
			// Registers itself with the ObjectManager
			ObjectManager.RegisterCharacter(this);
		}

		public void OnDestroy() {
			// Unregisters itself from the ObjectManager
			ObjectManager.UnregisterCharacter(this);
		}

	}

}
