using SaguFramework;
using UnityEngine;

namespace EmergenciaQuimica {
	
	public class ExitConfirmationMenuBehaviour : MenuBehaviour {
		
		public override void OnShowing() {
			if (GUILayout.Button("Cancelar")) // TODO: use LanguageManager
				OnCancelButtonActuated();
			
			if (GUILayout.Button("Salir")) // TODO: use LanguageManager
				OnExitButtonActuated();
		}

		private void OnCancelButtonActuated() {
			// Closes this menu
			GameManager.CloseMenu();
		}
		
		private void OnExitButtonActuated() {
			// Exits the game
			GameManager.Exit();
		}
		
	}
	
}
