using UnityEngine;

namespace SaguFramework {
	
	public class Character : MonoBehaviour {
		
		public void SetPosition(Vector2 position) {
			transform.position = Utilities.GetPosition(position, transform.position.z);
		}

		private Animator GetAnimator() {
			return GetComponent<Animator>();
		}

		private CharacterBehaviour GetBehaviour() {
			return GetComponentInChildren<CharacterBehaviour>();
		}

	}
	
}
