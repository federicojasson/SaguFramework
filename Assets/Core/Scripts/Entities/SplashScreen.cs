namespace SaguFramework {
	
	public class SplashScreen : Entity {

		public void OnEnable() {
			SetPosition(CameraHandler.GetCameraPosition());
		}

	}
	
}
