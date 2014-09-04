using UnityEngine;

namespace SaguFramework {
	
	public class Interactive : MonoBehaviour {

		public void OnMouseEnter() {
			GetBehaviour().OnCursorEnter();
		}
		
		public void SetSize(Vector2 size) {
			GetCollider().size = size;
		}
		
		private InteractiveBehaviour GetBehaviour() {
			return GetComponentInChildren<InteractiveBehaviour>();
		}

		private BoxCollider2D GetCollider() {
			return GetComponent<BoxCollider2D>();
		}

	}
	
}
