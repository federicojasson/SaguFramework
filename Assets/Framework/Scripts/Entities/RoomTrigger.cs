using UnityEngine;

namespace SaguFramework {

	/// The room triggers are used to detect events when the characters go through some sector.
	public sealed class RoomTrigger : Entity {

		public override void Awake() {
			base.Awake();

			// Gets the collider and makes it a trigger
			BoxCollider2D collider = GetCollider();
			collider.isTrigger = true;

			// Gets the rigid body and makes it non-kinematic
			// This is mandatory to trigger events
			Rigidbody2D rigidbody = GetRigidbody();
			rigidbody.angularDrag = 0;
			rigidbody.drag = 0;
			rigidbody.fixedAngle = true;
			rigidbody.gravityScale = 0;
			rigidbody.isKinematic = false;
		}

	}
	
}
