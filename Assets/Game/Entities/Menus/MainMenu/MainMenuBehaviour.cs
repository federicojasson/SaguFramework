using SaguFramework;
using UnityEngine;

namespace EmergenciaQuimica {
	
	public sealed class MainMenuBehaviour : MenuBehaviour {

		private bool isEnabled;
		
		public void Awake() {
			isEnabled = true;
		}
		
		public override void OnShowGui() {
			if (isEnabled)
				GUI.enabled = true;
			else
				GUI.enabled = false;

			GUIStyle menuButtonStyle = Framework.GetStyle("MenuButton");

			Framework.BeginArea(0.1f, 0.1f, 0.3f, 0.8f); {
				
				GUILayout.FlexibleSpace();

				if (GUILayout.Button(Framework.GetText("MainMenuNewGameButton"), menuButtonStyle))
					OnNewGame();

				GUILayout.FlexibleSpace();
				
				if (GUILayout.Button(Framework.GetText("MainMenuLoadGameButton"), menuButtonStyle))
					OnLoadGame();

				GUILayout.FlexibleSpace();
				
				if (GUILayout.Button(Framework.GetText("MainMenuOptionsButton"), menuButtonStyle))
					OnOptions();

				GUILayout.FlexibleSpace();
				
				if (GUILayout.Button(Framework.GetText("MainMenuExitButton"), menuButtonStyle))
					OnExit();
				
				GUILayout.FlexibleSpace();

			} Framework.EndArea();
		}
		
		private void OnExit() {
			Framework.OpenMenu("MainExitConfirmationMenu");
		}
		
		private void OnLoadGame() {
			Framework.OpenMenu("MainLoadGameMenu");
		}
		
		private void OnNewGame() {
			isEnabled = false;
			Framework.NewGame("Information");
		}
		
		private void OnOptions() {
			Framework.OpenMenu("MainOptionsMenu");
		}
		
	}
	
}
