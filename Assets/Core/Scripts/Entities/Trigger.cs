using UnityEngine;

namespace SaguFramework {
	
	public class Trigger : MonoBehaviour {
		
		public void OnTriggerEnter2D(Collider2D collider) {
			GetTriggerBehaviour().OnFire();
		}
		
		public void SetPosition(Vector2 position) {
			transform.position = Utilities.GetPosition(position, transform.position.z);
		}

		public void SetSize(Vector2 size) {
			GetCollider().size = size;
		}
		
		private BoxCollider2D GetCollider() {
			return GetComponent<BoxCollider2D>();
		}
		
		private TriggerBehaviour GetTriggerBehaviour() {
			return GetComponentInChildren<TriggerBehaviour>();
		}
		
	}
	
}
