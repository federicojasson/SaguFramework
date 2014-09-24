namespace SaguFramework {

	/// A menu.
	public sealed class Menu : Entity {

		public void Update() {
			// Follows the camera
			SetPosition(CameraHandler.GetCameraPosition());
		}

	}
	
}
