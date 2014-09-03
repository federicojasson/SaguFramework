using UnityEngine;

namespace SaguFramework {
	
	public class Interactive : MonoBehaviour {

		public void OnMouseEnter() {
			GetInteractiveBehaviour().OnCursorEnter();
		}
		
		public void SetSize(Vector2 size) {
			GetCollider().size = size;
		}

		private BoxCollider2D GetCollider() {
			return GetComponent<BoxCollider2D>();
		}

		private InteractiveBehaviour GetInteractiveBehaviour() {
			return GetComponentInChildren<InteractiveBehaviour>();
		}

	}
	
}
