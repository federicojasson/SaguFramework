using SaguFramework;
using UnityEngine;

namespace EmergenciaQuimica {
	
	public class OptionsMenuBehaviour : MenuBehaviour {
		
		public override void OnShowing() {
			if (GUILayout.Button(Language.GetText("OptionsMenuApplyChangesButton")))
				OnApplyChanges();

			if (GUILayout.Button(Language.GetText("OptionsMenuCancelButton")))
				OnCancel();
		}

		private void OnApplyChanges() {
			// TODO
		}
		
		private void OnCancel() {
			Game.CloseMenu();
		}
		
	}
	
}
