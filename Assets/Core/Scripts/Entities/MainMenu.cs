namespace SaguFramework {
	
	public class MainMenu : Menu {

		public override void Awake() {
			// Registers itself with the ObjectManager
			ObjectManager.RegisterMainMenu(this);

			// Sets itself as the game camera's passive target
			GameCamera.GetInstance().SetTarget(transform, false);
		}
		
		public override void OnDestroy() {
			// Unregisters itself from the ObjectManager
			ObjectManager.UnregisterMainMenu();
		}

	}
	
}
