using UnityEngine;

namespace SaguFramework {
	
	public class Trigger : MonoBehaviour {
		
		public void OnTriggerEnter2D(Collider2D collider) {
			InputHandler.GetInstance().NotifyOnTriggerEnter2D(GetBehaviour());
		}

		public void OnTriggerExit2D(Collider2D collider) {
			InputHandler.GetInstance().NotifyOnTriggerExit2D(GetBehaviour());
		}
		
		public void SetPosition(Vector2 position) {
			transform.position = Utilities.GetPosition(position, transform.position.z);
		}

		public void SetSize(Vector2 size) {
			GetCollider().size = size;
		}
		
		private TriggerBehaviour GetBehaviour() {
			return GetComponentInChildren<TriggerBehaviour>();
		}
		
		private BoxCollider2D GetCollider() {
			return GetComponent<BoxCollider2D>();
		}
		
	}
	
}
