using UnityEngine;

namespace SaguFramework {
	
	public class Interactive : MonoBehaviour {

		public void OnMouseEnter() {
			if (Geometry.GetGameRectangleInScreen().Contains(Input.mousePosition))
				InputHandler.GetInstance().NotifyOnMouseEnter(GetBehaviour());
		}

		public void OnMouseExit() {
			if (Geometry.GetGameRectangleInScreen().Contains(Input.mousePosition))
				InputHandler.GetInstance().NotifyOnMouseExit(GetBehaviour());
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
