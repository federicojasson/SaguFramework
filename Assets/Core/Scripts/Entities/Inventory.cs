namespace SaguFramework {

	// TODO: comentar

	public sealed class Inventory : Entity {

		public void Update() {
			SetPosition(CameraHandler.GetCameraPosition());
		}

	}
	
}
