namespace SaguFramework {
	
	public class Inventory : Entity {
		
		public void OnEnable() {
			SetPosition(CameraHandler.GetCameraPosition());
		}

	}
	
}
