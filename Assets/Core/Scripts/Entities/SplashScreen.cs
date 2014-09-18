namespace SaguFramework {
	
	public sealed class SplashScreen : Entity {

		public void Update() {
			SetPosition(CameraHandler.GetCameraPosition());
		}

	}
	
}
