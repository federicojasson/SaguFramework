using SaguFramework;
using UnityEngine;

namespace EmergenciaQuimica {
	
	public class GoBackConfirmationMenuBehaviour : MenuBehaviour {
		
		private bool isEnabled;
		
		public void Awake() {
			isEnabled = true;
		}
		
		public override void OnShowGui() {
			if (isEnabled)
				GUI.enabled = true;
			else
				GUI.enabled = false;

			if (GUILayout.Button(Language.GetText("GoBackConfirmationMenuCancelButton")))
				OnCancel();
			
			if (GUILayout.Button(Language.GetText("GoBackConfirmationMenuGoBackButton")))
				OnGoBack();
		}
		
		private void OnCancel() {
			Game.CloseMenu();
		}
		
		private void OnGoBack() {
			isEnabled = false;
			Game.OpenMainMenu();
		}
		
	}
	
}
