using UnityEngine;

namespace SaguFramework {

	// TODO: comentar

	public sealed class InventoryTrigger : Entity {

		private Vector2 offset;

		public void SetOffset(Vector2 offset) {
			this.offset = offset;
		}

		public void Update() {
			SetPosition(CameraHandler.GetCameraPosition() + offset);
		}

	}
	
}
