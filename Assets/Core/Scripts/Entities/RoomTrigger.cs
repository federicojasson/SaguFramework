using UnityEngine;

namespace SaguFramework {
	
	public class RoomTrigger : Entity {

		public override void Awake() {
			base.Awake();

			BoxCollider2D collider = GetCollider();
			collider.isTrigger = true;

			Rigidbody2D rigidbody = GetRigidbody();
			rigidbody.angularDrag = 0;
			rigidbody.drag = 0;
			rigidbody.fixedAngle = true;
			rigidbody.gravityScale = 0;
			rigidbody.isKinematic = false;
		}

	}
	
}
