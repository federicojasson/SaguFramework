using SaguFramework;
using UnityEngine;

namespace EmergenciaQuimica {
	
	public sealed class LoadGameMenuBehaviour : MenuBehaviour {
		
		private bool isEnabled;
		private string[] options;
		private Vector2 scrollPosition;
		private int selectedOption;
		private StateFile[] stateFiles;
		private int stateLastCount;

		public void Awake() {
			isEnabled = true;
			stateLastCount = -1;
		}

		public void OnEnable() {
			stateFiles = Framework.GetStateFiles();
			options = new string[stateFiles.Length];
			for (int i = 0; i < options.Length; i++) {
				StateFile stateFile = stateFiles[i];
				options[i] = stateFile.GetId() + " [" + stateFile.GetModificationTime() + "]";
			}
			
			int auxiliar = stateLastCount;
			stateLastCount = stateFiles.Length;

			if (stateLastCount != auxiliar)
				selectedOption = -1;
		}

		public override void OnShowGui() {
			if (isEnabled)
				GUI.enabled = true;
			else
				GUI.enabled = false;

			GUIStyle menuButtonStyle = Framework.GetStyle("MenuButton");
			GUIStyle menuSelectionGridStyle = Framework.GetStyle("MenuSelectionGrid");
			GUIStyle menuTitleStyle = Framework.GetStyle("MenuTitle");
			GUIStyle scrollViewStyle = Framework.GetStyle(GUI.skin.scrollView.name);

			Framework.BeginArea(0.05f, 0.05f, 0.9f, 0.1f); {
				GUILayout.Label(Framework.GetText("LoadGameMenuTitleLabel"), menuTitleStyle);
			} Framework.EndArea();

			Framework.BeginArea(0.1f, 0.18f, 0.8f, 0.77f); {
				Framework.BeginArea(0f, 0f, 1f, 0.75f); {
					scrollPosition = GUILayout.BeginScrollView(scrollPosition, scrollViewStyle); {
						selectedOption = GUILayout.SelectionGrid(selectedOption, options, 1, menuSelectionGridStyle);
					} GUILayout.EndScrollView();
				} Framework.EndArea();

				Framework.BeginArea(0f, 0.8f, 0.32f, 0.2f); {
					if (GUILayout.Button(Framework.GetText("LoadGameMenuCancelButton"), menuButtonStyle))
						OnCancel();
				} Framework.EndArea();

				Framework.BeginArea(0.34f, 0.8f, 0.32f, 0.2f); {
					if (selectedOption < 0)
						GUI.enabled = false;
					
					if (GUILayout.Button(Framework.GetText("LoadGameMenuDeleteGameButton"), menuButtonStyle))
						OnDeleteGame();
					
					GUI.enabled = isEnabled;
				} Framework.EndArea();

				Framework.BeginArea(0.68f, 0.8f, 0.32f, 0.2f); {
					if (selectedOption < 0)
						GUI.enabled = false;

					if (GUILayout.Button(Framework.GetText("LoadGameMenuLoadGameButton"), menuButtonStyle))
						OnLoadGame();

					GUI.enabled = isEnabled;
				} Framework.EndArea();
			} Framework.EndArea();
		}
		
		private void OnCancel() {
			Framework.CloseMenu();
		}
		
		private void OnDeleteGame() {
			string stateId = stateFiles[selectedOption].GetId();
			DeleteGameConfirmationMenuBehaviour.SetStateId(stateId);
			
			if (Framework.IsMainMenuOpen())
				Framework.OpenMenu("MainDeleteGameConfirmationMenu");
			else
				Framework.OpenMenu("PauseDeleteGameConfirmationMenu");
		}

		private void OnLoadGame() {
			isEnabled = false;
			string stateId = stateFiles[selectedOption].GetId();
			Framework.LoadGame(stateId, "Information");
		}
		
	}
	
}
