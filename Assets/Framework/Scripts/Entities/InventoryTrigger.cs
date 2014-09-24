using UnityEngine;

namespace SaguFramework {

	/// The inventory triggers are used to detect events when the inventory is being shown.
	public sealed class InventoryTrigger : Entity {

		private Vector2 offset; // The offset from the camera

		/// Sets the offset in world space.
		public void SetOffset(Vector2 offset) {
			this.offset = offset;
		}

		public void Update() {
			// Follows the camera (and applies an offset)
			SetPosition(CameraHandler.GetCameraPosition() + offset);
		}

	}
	
}
