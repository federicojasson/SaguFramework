namespace SaguFramework {
	
	public class Menu : Entity {

		public void Close() {
			DestroyImmediate(gameObject);
		}
		
		public void OnEnable() {
			SetPosition(CameraHandler.GetCameraPosition());
		}

	}
	
}
