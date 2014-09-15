using SaguFramework;
using UnityEngine;

namespace EmergenciaQuimica {
	
	public class PauseMenuBehaviour : MenuBehaviour {
		
		public override void OnShowGui() {
			GUIStyle menuButtonStyle = GUI.skin.GetStyle("MenuButton");
			GUIStyle modifiedMenuButtonStyle = Utilities.GetRelativeStyle(menuButtonStyle);
			
			float gameWidth = Geometry.GetGameWidthInPixels();
			float gameHeight = Geometry.GetGameHeightInPixels();
			
			Rect area = new Rect(0.1f * gameWidth, 0.1f * gameHeight, 0.3f * gameWidth, 0.8f * gameHeight);
			GUILayout.BeginArea(area); {
				GUILayout.FlexibleSpace();

				if (GUILayout.Button(Language.GetText("PauseMenuResumeGameButton"), modifiedMenuButtonStyle))
					OnResumeGame();
				
				GUILayout.FlexibleSpace();
				
				if (GUILayout.Button(Language.GetText("PauseMenuSaveGameButton"), modifiedMenuButtonStyle))
					OnSaveGame();
				
				GUILayout.FlexibleSpace();
				
				if (GUILayout.Button(Language.GetText("PauseMenuLoadGameButton"), modifiedMenuButtonStyle))
					OnLoadGame();
				
				GUILayout.FlexibleSpace();
				
				if (GUILayout.Button(Language.GetText("PauseMenuOptionsButton"), modifiedMenuButtonStyle))
					OnOptions();
				
				GUILayout.FlexibleSpace();
				
				if (GUILayout.Button(Language.GetText("PauseMenuGoBackButton"), modifiedMenuButtonStyle))
					OnGoBack();

				GUILayout.FlexibleSpace();

				if (GUILayout.Button(Language.GetText("PauseMenuExitButton"), modifiedMenuButtonStyle))
					OnExit();
				
				GUILayout.FlexibleSpace();
			} GUILayout.EndArea();
		}

		private void OnExit() {
			Game.OpenMenu("PauseExitConfirmationMenu");
		}

		private void OnGoBack() {
			Game.OpenMenu("GoBackConfirmationMenu");
		}

		private void OnLoadGame() {
			Game.OpenMenu("PauseLoadGameMenu");
		}

		private void OnOptions() {
			Game.OpenMenu("PauseOptionsMenu");
		}

		private void OnResumeGame() {
			Game.CloseMenu();
		}

		private void OnSaveGame() {
			Game.OpenMenu("SaveGameMenu");
		}
		
	}
	
}
