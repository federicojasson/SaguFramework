namespace SaguFramework {

	/// The inventory.
	public sealed class Inventory : Entity {

		public void Update() {
			// Follows the camera
			SetPosition(CameraHandler.GetCameraPosition());
		}

	}
	
}
