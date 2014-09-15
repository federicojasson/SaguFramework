using SaguFramework;

namespace EmergenciaQuimica {
	
	public class PauseLoadGameMenuBehaviour : LoadGameMenuBehaviour {

		protected override string GetDeleteStateConfirmationMenuId() {
			return "PauseDeleteStateConfirmationMenu";
		}

	}
	
}
