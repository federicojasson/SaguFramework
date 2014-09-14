using SaguFramework;
using UnityEngine;

namespace EmergenciaQuimica {
	
	public class MainMenuBehaviour : MenuBehaviour {

		private bool isEnabled;

		public void Awake() {
			isEnabled = true;
		}

		public override void OnShowGui() {
			if (isEnabled)
				GUI.enabled = true;
			else
				GUI.enabled = false;

			GUIStyle menuButtonStyle = GUI.skin.GetStyle("MenuButton");
			GUIStyle modifiedMenuButtonStyle = Utilities.GetRelativeStyle(menuButtonStyle);

			float gameWidth = Geometry.GetGameWidthInPixels();
			float gameHeight = Geometry.GetGameHeightInPixels();

			Rect area = new Rect(0.1f * gameWidth, 0.1f * gameHeight, 0.3f * gameWidth, 0.8f * gameHeight);
			GUILayout.BeginArea(area); {
				GUILayout.FlexibleSpace();

				if (GUILayout.Button(Language.GetText("MainMenuNewGameButton"), modifiedMenuButtonStyle))
					OnNewGame();

				GUILayout.FlexibleSpace();

				if (GUILayout.Button(Language.GetText("MainMenuLoadGameButton"), modifiedMenuButtonStyle))
					OnLoadGame();

				GUILayout.FlexibleSpace();

				if (GUILayout.Button(Language.GetText("MainMenuOptionsButton"), modifiedMenuButtonStyle))
					OnOptions();

				GUILayout.FlexibleSpace();

				if (GUILayout.Button(Language.GetText("MainMenuExitButton"), modifiedMenuButtonStyle))
					OnExit();

				GUILayout.FlexibleSpace();
			} GUILayout.EndArea();
		}

		private void OnExit() {
			Game.OpenMenu("ExitConfirmationMenu");
		}

		private void OnLoadGame() {
			Game.OpenMenu("MainLoadGameMenu");
		}

		private void OnNewGame() {
			isEnabled = false;
			Game.NewGame("Information");
		}

		private void OnOptions() {
			Game.OpenMenu("MainOptionsMenu");
		}
		
	}
	
}
