using SaguFramework;
using System.Linq;
using UnityEngine;

namespace EmergenciaQuimica {
	
	public sealed class SaveGameMenuBehaviour : MenuBehaviour {

		private string newStateId;
		private Vector2 scrollPosition;
		private int selectedStateId;
		private string[] stateIds;
		
		public void Awake() {
			newStateId = string.Empty;
			selectedStateId = -1;
			stateIds = new string[0];
		}

		public void OnEnable() {
			string[] previousStateIds = stateIds;
			stateIds = State.GetStateIds();

			if (stateIds.Length != previousStateIds.Length) {
				selectedStateId = -1;
				return;
			}

			for (int i = 0; i < stateIds.Length; i++)
				if (stateIds[i] != previousStateIds[i]) {
					selectedStateId = -1;
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
							selectedStateId = -1;
					} Framework.EndArea();
				} Framework.EndArea();

				Framework.BeginArea(0f, 0.12f, 1f, 0.63f); {
					scrollPosition = GUILayout.BeginScrollView(scrollPosition, scrollViewStyle); {
						selectedStateId = GUILayout.SelectionGrid(selectedStateId, stateIds, 1, menuSelectionGridStyle);
					} GUILayout.EndScrollView();

					if (selectedStateId >= 0)
						newStateId = string.Empty;
				} Framework.EndArea();

				Framework.BeginArea(0f, 0.8f, 0.32f, 0.2f); {
					if (GUILayout.Button(Framework.GetText("SaveGameMenuCancelButton"), menuButtonStyle))
						OnCancel();
				} Framework.EndArea();

				Framework.BeginArea(0.34f, 0.8f, 0.32f, 0.2f); {
					if (selectedStateId < 0)
						GUI.enabled = false;

					if (GUILayout.Button(Framework.GetText("SaveGameMenuDeleteGameButton"), menuButtonStyle))
						OnDeleteGame();

					GUI.enabled = true;
				} Framework.EndArea();

				Framework.BeginArea(0.68f, 0.8f, 0.32f, 0.2f); {
					if (newStateId.Trim().Length == 0 && selectedStateId < 0)
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
			string stateId = stateIds[selectedStateId];
			DeleteGameConfirmationMenuBehaviour.SetStateId(stateId);
			Framework.OpenMenu("PauseDeleteGameConfirmationMenu");
		}
		
		private void OnSaveGame() {
			string stateId;
			if (selectedStateId < 0)
				stateId = newStateId.Trim();
			else
				stateId = stateIds[selectedStateId];

			if (stateIds.Contains(stateId)) {
				OverwriteGameConfirmationMenuBehaviour.SetStateId(stateId);
				Framework.OpenMenu("OverwriteGameConfirmationMenu");
				return;
			}
			
			Framework.SaveGame(stateId);
			Framework.CloseMenu();
		}

	}
	
}
