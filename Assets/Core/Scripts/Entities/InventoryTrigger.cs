using UnityEngine;

namespace SaguFramework {
	
	public class InventoryTrigger : Entity {

		public void OnEnable() {
			Vector2 inventoryPosition = Objects.GetInventory().GetPosition();
			Vector2 offset = GetPosition() - inventoryPosition;
			SetPosition(CameraHandler.GetCameraPosition() + offset);
		}

	}
	
}
