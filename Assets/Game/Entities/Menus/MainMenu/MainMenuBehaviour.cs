using SaguFramework;
using UnityEngine;

namespace EmergenciaQuimica {
	
	public class MainMenuBehaviour : MenuBehaviour {

		private bool isLocked;

		public void Awake() {
			isLocked = false;
		}

		public override void OnShowGui() {
			if (GUILayout.Button(Language.GetText("MainMenuNewGameButton")))
				OnNewGame();
			
			if (GUILayout.Button(Language.GetText("MainMenuLoadGameButton")))
				OnLoadGame();
			
			if (GUILayout.Button(Language.GetText("MainMenuOptionsButton")))
				OnOptions();
			
			if (GUILayout.Button(Language.GetText("MainMenuExitButton")))
				OnExit();
		}

		private void OnExit() {
			if (! isLocked)
				Game.OpenMenu("ExitConfirmationMenu");
		}

		private void OnLoadGame() {
			if (! isLocked)
				Game.OpenMenu("LoadGameMenu");
		}

		private void OnNewGame() {
			if (! isLocked) {
				isLocked = true;
				Game.NewGame("Information");
			}
		}

		private void OnOptions() {
			if (! isLocked)
				Game.OpenMenu("OptionsMenu");
		}
		
	}
	
}
