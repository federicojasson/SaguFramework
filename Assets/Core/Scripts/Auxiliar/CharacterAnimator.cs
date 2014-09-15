using UnityEngine;

namespace SaguFramework {
	
	public class CharacterAnimator : MonoBehaviour {

		private Animator animator;

		public void Awake() {
			animator = gameObject.AddComponent<Animator>();
		}

		public void SetAnimatorController(RuntimeAnimatorController animatorController) {
			animator.runtimeAnimatorController = animatorController;
		}

		// TODO
		public void SetSize(Vector2 size) {
			transform.localScale = new Vector3(size.x, size.y, transform.localScale.z);
		}

	}
	
}
