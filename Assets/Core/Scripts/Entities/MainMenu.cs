using SaguFramework.Managers;

namespace SaguFramework.Entities {
	
	public class MainMenu : Menu {

		public override void Awake() {
			// Registers itself with the ObjectManager
			ObjectManager.RegisterMainMenu(this);
		}
		
		public override void OnDestroy() {
			// Unregisters itself from the ObjectManager
			ObjectManager.UnregisterMainMenu();
		}

	}
	
}
