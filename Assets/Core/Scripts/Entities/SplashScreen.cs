namespace SaguFramework {

	// TODO: comentar

	public sealed class SplashScreen : Entity {

		public void Update() {
			SetPosition(CameraHandler.GetCameraPosition());
		}

	}
	
}
