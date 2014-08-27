using UnityEngine;

namespace SaguFramework {

	public class Character : MonoBehaviour {
		
		private CharacterBehaviour behaviour;

		public void Awake() {
			// Registers itself with the ObjectManager
			ObjectManager.RegisterCharacter(this);
		}

		public void OnDestroy() {
			// Unregisters itself from the ObjectManager
			ObjectManager.UnregisterCharacter(this);
		}
		
		public void SetBehaviour(CharacterBehaviour behaviour) {
			this.behaviour = behaviour;
		}

	}

}
