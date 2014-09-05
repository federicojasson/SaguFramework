using SaguFramework;
using UnityEngine;

namespace EmergenciaQuimica {
	
	public class LoadGameMenuBehaviour : MenuBehaviour {
		
		public override void OnShowing() {
			if (GUILayout.Button(Language.GetText("LoadGameMenuCancelButton")))
				OnCancel();
		}
		
		private void OnCancel() {
			Game.CloseMenu();
		}
		
	}
	
}
