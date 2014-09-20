using SaguFramework;
using UnityEngine;

namespace EmergenciaQuimica {
	
	public sealed class PauseMenuBehaviour : MenuBehaviour {
		
		public override void OnShowGui() {
			GUIStyle menuButtonStyle = Framework.GetStyle("MenuButton");

			GameGui.BeginArea(0.1f, 0.1f, 0.3f, 0.8f); {
				GUILayout.FlexibleSpace();

				if (GUILayout.Button(Language.GetText("PauseMenuResumeGameButton"), menuButtonStyle))
					OnResumeGame();
				
				GUILayout.FlexibleSpace();
				
				if (GUILayout.Button(Language.GetText("PauseMenuSaveGameButton"), menuButtonStyle))
					OnSaveGame();
				
				GUILayout.FlexibleSpace();
				
				if (GUILayout.Button(Language.GetText("PauseMenuLoadGameButton"), menuButtonStyle))
					OnLoadGame();
				
				GUILayout.FlexibleSpace();
				
				if (GUILayout.Button(Language.GetText("PauseMenuOptionsButton"), menuButtonStyle))
					OnOptions();
				
				GUILayout.FlexibleSpace();
				
				if (GUILayout.Button(Language.GetText("PauseMenuGoBackButton"), menuButtonStyle))
					OnGoBack();

				GUILayout.FlexibleSpace();

				if (GUILayout.Button(Language.GetText("PauseMenuExitButton"), menuButtonStyle))
					OnExit();
				
				GUILayout.FlexibleSpace();
			} GameGui.EndArea();
		}

		private void OnExit() {
			Framework.OpenMenu("PauseExitConfirmationMenu");
		}

		private void OnGoBack() {
			Framework.OpenMenu("GoBackConfirmationMenu");
		}

		private void OnLoadGame() {
			Framework.OpenMenu("PauseLoadGameMenu");
		}

		private void OnOptions() {
			Framework.OpenMenu("PauseOptionsMenu");
		}

		private void OnResumeGame() {
			Framework.CloseMenu();
		}

		private void OnSaveGame() {
			Framework.OpenMenu("SaveGameMenu");
		}
		
	}
	
}
