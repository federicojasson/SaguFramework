using UnityEngine;

namespace SaguFramework {
	
	public class RoomTrigger : Entity {

		public override void Awake() {
			base.Awake();
			Rigidbody2D rigidbody = gameObject.AddComponent<Rigidbody2D>();
			rigidbody.isKinematic = false;
			rigidbody.gravityScale = 0;
			rigidbody.fixedAngle = true;
			BoxCollider2D collider = GetComponent<BoxCollider2D>();
			collider.isTrigger = true;
		}

	}
	
}
