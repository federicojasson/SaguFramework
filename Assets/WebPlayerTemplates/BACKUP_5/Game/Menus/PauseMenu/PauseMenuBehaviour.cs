using SaguFramework;
using UnityEngine;

namespace EmergenciaQuimica {
	
	public class PauseMenuBehaviour : MenuBehaviour {
		
		public override void OnShowGui() {
			if (GUILayout.Button(Language.GetText("PauseMenuResumeGameButton")))
				OnResumeGame();

			if (GUILayout.Button(Language.GetText("PauseMenuSaveGameButton")))
				OnSaveGame();

			if (GUILayout.Button(Language.GetText("PauseMenuGoBackButton")))
				OnGoBack();
		}

		private void OnGoBack() {
			Game.OpenMenu("GoBackConfirmationMenu");
		}

		private void OnResumeGame() {
			Game.CloseMenu();
		}

		private void OnSaveGame() {
			Game.OpenMenu("SaveGameMenu");
		}
		
	}
	
}
