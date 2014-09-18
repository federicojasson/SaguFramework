using UnityEngine;

namespace SaguFramework {
	
	public sealed class InventoryTrigger : Entity {

		private Vector2 offset;

		public void SetOffset(Vector2 offset) {
			this.offset = offset;
		}

		public void Update() {
			Vector2 inventoryPosition = Objects.GetInventory().GetPosition();
			Vector2 position = CameraHandler.GetCameraPosition() + offset;
			SetPosition(position);
		}

	}
	
}
