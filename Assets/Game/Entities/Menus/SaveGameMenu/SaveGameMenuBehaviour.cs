using SaguFramework;
using UnityEngine;

namespace EmergenciaQuimica {
	
	public sealed class SaveGameMenuBehaviour : MenuBehaviour {

		private string newStateId;
		private string[] options;
		private Vector2 scrollPosition;
		private int selectedOption;
		private StateFile[] stateFiles;
		
		public void Awake() {
			newStateId = string.Empty;
			selectedOption = -1;
			stateFiles = new StateFile[0];
		}

		public void OnEnable() {
			StateFile[] previousStates = stateFiles;

			stateFiles = Framework.GetStateFiles();
			options = new string[stateFiles.Length];
			for (int i = 0; i < options.Length; i++) {
				StateFile stateFile = stateFiles[i];
				options[i] = stateFile.GetId() + " [" + stateFile.GetModificationTime() + "]";
			}

			if (stateFiles.Length != previousStates.Length) {
				selectedOption = -1;
				return;
			}

			for (int i = 0; i < stateFiles.Length; i++)
				if (! stateFiles[i].Equals(previousStates[i])) {
					selectedOption = -1;
					return;
				}
		}

		public override void OnShowGui() {
			GUIStyle menuButtonStyle = Framework.GetStyle("MenuButton");
			GUIStyle menuLabelStyle = Framework.GetStyle("MenuLabel");
			GUIStyle menuSelectionGridStyle = Framework.GetStyle("MenuSelectionGrid");
			GUIStyle menuTitleStyle = Framework.GetStyle("MenuTitle");
			GUIStyle scrollViewStyle = Framework.GetStyle(GUI.skin.scrollView.name);
			GUIStyle textFieldStyle = Framework.GetStyle(GUI.skin.textField.name);

			Framework.BeginArea(0.05f, 0.05f, 0.9f, 0.1f); {
				GUILayout.Label(Framework.GetText("SaveGameMenuTitleLabel"), menuTitleStyle);
			} Framework.EndArea();

			Framework.BeginArea(0.1f, 0.18f, 0.8f, 0.77f); {
				Framework.BeginArea(0f, 0f, 1f, 0.1f); {
					Framework.BeginArea(0f, 0f, 0.35f, 1f); {
						GUILayout.Label(Framework.GetText("SaveGameMenuGameLabel"), menuLabelStyle);
					} Framework.EndArea();

					Framework.BeginArea(0.38f, 0f, 0.62f, 1f); {
						newStateId = FilterStateId(GUILayout.TextField(newStateId, textFieldStyle));
						
						if (newStateId.Trim().Length > 0)
							selectedOption = -1;
					} Framework.EndArea();
				} Framework.EndArea();

				Framework.BeginArea(0f, 0.12f, 1f, 0.63f); {
					scrollPosition = GUILayout.BeginScrollView(scrollPosition, scrollViewStyle); {
						selectedOption = GUILayout.SelectionGrid(selectedOption, options, 1, menuSelectionGridStyle);
					} GUILayout.EndScrollView();

					if (selectedOption >= 0)
						newStateId = string.Empty;
				} Framework.EndArea();

				Framework.BeginArea(0f, 0.8f, 0.32f, 0.2f); {
					if (GUILayout.Button(Framework.GetText("SaveGameMenuCancelButton"), menuButtonStyle))
						OnCancel();
				} Framework.EndArea();

				Framework.BeginArea(0.34f, 0.8f, 0.32f, 0.2f); {
					if (selectedOption < 0)
						GUI.enabled = false;

					if (GUILayout.Button(Framework.GetText("SaveGameMenuDeleteGameButton"), menuButtonStyle))
						OnDeleteGame();

					GUI.enabled = true;
				} Framework.EndArea();

				Framework.BeginArea(0.68f, 0.8f, 0.32f, 0.2f); {
					if (newStateId.Trim().Length == 0 && selectedOption < 0)
						GUI.enabled = false;

					if (GUILayout.Button(Framework.GetText("SaveGameMenuSaveGameButton"), menuButtonStyle))
						OnSaveGame();

					GUI.enabled = true;
				} Framework.EndArea();
			} Framework.EndArea();
		}
		
		private string FilterStateId(string stateId) {
			if (stateId.Length > 32)
				stateId = stateId.Substring(0, 32);

			string temporalStateId = stateId.ToUpperInvariant();
			string filteredStateId = string.Empty;
			
			for (int i = 0; i < temporalStateId.Length; i++) {
				char character = temporalStateId[i];
				
				if (character >= 'A' && character <= 'Z') {
					filteredStateId += character;
					continue;
				}
				
				if (character >= '0' && character <= '9') {
					filteredStateId += character;
					continue;
				}
				
				switch (character) {
					case ' ' :
					case '_' :
					case '-' : {
						filteredStateId += character;
						continue;
					}
				}
			}
			
			return filteredStateId;
		}
		
		private void OnCancel() {
			Framework.CloseMenu();
		}

		private void OnDeleteGame() {
			string stateId = stateFiles[selectedOption].GetId();
			DeleteGameConfirmationMenuBehaviour.SetStateId(stateId);
			Framework.OpenMenu("PauseDeleteGameConfirmationMenu");
		}
		
		private void OnSaveGame() {
			string stateId;
			if (selectedOption < 0)
				stateId = newStateId.Trim();
			else
				stateId = stateFiles[selectedOption].GetId();

			foreach (StateFile stateFile in stateFiles)
				if (stateFile.GetId() == stateId) {
					OverwriteGameConfirmationMenuBehaviour.SetStateId(stateId);
					Framework.OpenMenu("OverwriteGameConfirmationMenu");
					return;
				}
			
			Framework.SaveGame(stateId);
			Framework.CloseMenu();
		}

	}
	
}
