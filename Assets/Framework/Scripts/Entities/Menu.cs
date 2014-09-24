namespace SaguFramework {

	/// A menu.
	public sealed class Menu : Entity {

		public override void Destroy() {
			// Destroys the menu immediately
			DestroyImmediate(gameObject);
		}

		public void Update() {
			// Follows the camera
			SetPosition(CameraHandler.GetCameraPosition());
		}

	}
	
}
