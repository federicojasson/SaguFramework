namespace SaguFramework {

	// TODO: comentar

	public sealed class Menu : Entity {

		public void Update() {
			SetPosition(CameraHandler.GetCameraPosition());
		}

	}
	
}
