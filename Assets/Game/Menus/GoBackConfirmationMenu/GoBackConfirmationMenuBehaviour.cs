using SaguFramework;
using UnityEngine;

namespace EmergenciaQuimica {
	
	public class GoBackConfirmationMenuBehaviour : MenuBehaviour {
		
		private bool isLocked;
		
		public void Awake() {
			isLocked = false;
		}
		
		public override void OnShowing() {
			if (GUILayout.Button(Language.GetText("GoBackConfirmationMenuCancelButton")))
				OnCancel();
			
			if (GUILayout.Button(Language.GetText("GoBackConfirmationMenuGoBackButton")))
				OnGoBack();
		}
		
		private void OnCancel() {
			if (! isLocked)
				Game.CloseMenu();
		}
		
		private void OnGoBack() {
			if (! isLocked) {
				isLocked = true;
				Game.OpenMainMenu();
			}
		}
		
	}
	
}
