namespace SaguFramework {
	
	public class Menu : Entity {
		
		public void OnEnable() {
			SetPosition(CameraHandler.GetCameraPosition());
		}

	}
	
}
