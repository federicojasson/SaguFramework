using SaguFramework;
using UnityEngine;

namespace EmergenciaQuimica {
	
	public class PauseMenuBehaviour : MenuBehaviour {
		
		public override void OnShowing() {
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
			Game.ResumeGame();
		}

		private void OnSaveGame() {
			Game.OpenMenu("SaveGameMenu");
		}
		
	}
	
}
