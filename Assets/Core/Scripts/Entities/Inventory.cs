namespace SaguFramework {
	
	public sealed class Inventory : Entity {

		public void Update() {
			SetPosition(CameraHandler.GetCameraPosition());
		}

	}
	
}
