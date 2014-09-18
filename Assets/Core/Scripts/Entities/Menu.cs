namespace SaguFramework {
	
	public sealed class Menu : Entity {

		public void Update() {
			SetPosition(CameraHandler.GetCameraPosition());
		}

	}
	
}
