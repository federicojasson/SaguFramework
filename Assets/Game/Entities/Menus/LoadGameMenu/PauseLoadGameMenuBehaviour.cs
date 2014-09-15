using SaguFramework;

namespace EmergenciaQuimica {
	
	public class PauseLoadGameMenuBehaviour : LoadGameMenuBehaviour {

		protected override string GetDeleteGameConfirmationMenuId() {
			return "PauseDeleteGameConfirmationMenu";
		}

	}
	
}
