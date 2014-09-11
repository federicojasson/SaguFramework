using SaguFramework;
using UnityEngine;

namespace EmergenciaQuimica {
	
	public class ExitConfirmationMenuBehaviour : MenuBehaviour {
		
		public override void OnShowGui() {
			if (GUILayout.Button(Language.GetText("ExitConfirmationMenuCancelButton")))
				OnCancel();
			
			if (GUILayout.Button(Language.GetText("ExitConfirmationMenuExitButton")))
				OnExit();
		}
		
		private void OnCancel() {
			Game.CloseMenu();
		}
		
		private void OnExit() {
			Game.Exit();
		}

	}
	
}
