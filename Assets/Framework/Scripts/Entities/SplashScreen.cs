namespace SaguFramework {

	/// A splash screen.
	public sealed class SplashScreen : Entity {

		public void Update() {
			// Follows the camera
			SetPosition(CameraHandler.GetCameraPosition());
		}

	}
	
}
