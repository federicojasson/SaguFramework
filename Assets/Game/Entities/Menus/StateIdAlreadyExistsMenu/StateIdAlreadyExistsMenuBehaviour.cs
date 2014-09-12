using SaguFramework;
using UnityEngine;

namespace EmergenciaQuimica {
	
	public class StateIdAlreadyExistsMenuBehaviour : MenuBehaviour {
		
		public override void OnShowGui() {
			if (GUILayout.Button(Language.GetText("StateIdAlreadyExistsMenuAcceptButton")))
				OnAccept();
		}
		
		private void OnAccept() {
			Game.CloseMenu();
		}
		
	}
	
}
