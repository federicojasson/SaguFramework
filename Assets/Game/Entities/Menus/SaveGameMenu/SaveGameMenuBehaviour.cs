using SaguFramework;
using System;
using System.Linq;
using UnityEngine;

namespace EmergenciaQuimica {
	
	public class SaveGameMenuBehaviour : MenuBehaviour {

		private string newStateId;
		private Vector2 scrollPosition;
		private int selectedStateId;
		private string[] stateIds;
		private int stateLastCount;
		
		public void Awake() {
			newStateId = string.Empty;
			stateLastCount = -1;
		}

		public void OnEnable() {
			int auxiliar = stateLastCount;
			stateIds = State.GetStateIds();
			stateLastCount = stateIds.Length;
			
			if (stateLastCount != auxiliar)
				selectedStateId = -1;
		}

		public override void OnShowGui() {
			GUIStyle menuButtonStyle = GUI.skin.GetStyle("MenuButton");
			GUIStyle modifiedMenuButtonStyle = Utilities.GetRelativeStyle(menuButtonStyle);
			
			GUIStyle menuLabelStyle = GUI.skin.GetStyle("MenuLabel");
			GUIStyle modifiedMenuLabelStyle = Utilities.GetRelativeStyle(menuLabelStyle);
			
			GUIStyle menuSelectionGridStyle = GUI.skin.GetStyle("MenuSelectionGrid");
			GUIStyle modifiedMenuSelectionGridStyle = Utilities.GetRelativeStyle(menuSelectionGridStyle);
			
			GUIStyle menuTitleStyle = GUI.skin.GetStyle("MenuTitle");
			GUIStyle modifiedMenuTitleStyle = Utilities.GetRelativeStyle(menuTitleStyle);

			GUIStyle scrollViewStyle = GUI.skin.scrollView;
			GUIStyle modifiedScrollViewStyle = Utilities.GetRelativeStyle(scrollViewStyle);

			GUIStyle textFieldStyle = GUI.skin.textField;
			GUIStyle modifiedTextFieldStyle = Utilities.GetRelativeStyle(textFieldStyle);
			
			float gameWidth = Geometry.GetGameWidthInPixels();
			float gameHeight = Geometry.GetGameHeightInPixels();
			
			Rect area0 = new Rect(0.05f * gameWidth, 0.05f * gameHeight, 0.9f * gameWidth, 0.1f * gameHeight);
			GUILayout.BeginArea(area0); {
				GUILayout.Label(Language.GetText("SaveGameMenuTitleLabel"), modifiedMenuTitleStyle);
			} GUILayout.EndArea();
			
			Rect area1 = new Rect(0.1f * gameWidth, 0.18f * gameHeight, 0.8f * gameWidth, 0.77f * gameHeight);
			GUILayout.BeginArea(area1); {
				Rect area10 = new Rect(0f, 0f, area1.width, 0.1f * area1.height);
				GUILayout.BeginArea(area10); {
					Rect area100 = new Rect(0f, 0f, 0.35f * area10.width, area10.height);
					GUILayout.BeginArea(area100); {
						GUILayout.Label(Language.GetText("SaveGameMenuGameLabel"), modifiedMenuLabelStyle);
					} GUILayout.EndArea();

					Rect area101 = new Rect(0.38f * area10.width, 0f, 0.62f * area10.width, area10.height);
					GUILayout.BeginArea(area101); {
						newStateId = FilterStateId(GUILayout.TextField(newStateId, modifiedTextFieldStyle));
						
						if (newStateId.Trim().Length > 0)
							selectedStateId = -1;
					} GUILayout.EndArea();
				} GUILayout.EndArea();
				
				Rect area11 = new Rect(0f, 0.12f * area1.height, area1.width, 0.63f * area1.height);
				GUILayout.BeginArea(area11); {
					scrollPosition = GUILayout.BeginScrollView(scrollPosition, modifiedScrollViewStyle); {
						selectedStateId = GUILayout.SelectionGrid(selectedStateId, stateIds, 1, modifiedMenuSelectionGridStyle);
					} GUILayout.EndScrollView();

					if (selectedStateId >= 0)
						newStateId = string.Empty;
				} GUILayout.EndArea();
				
				Rect area12 = new Rect(0f, 0.8f * area1.height, 0.32f * area1.width, 0.2f * area1.height);
				GUILayout.BeginArea(area12); {
					if (GUILayout.Button(Language.GetText("SaveGameMenuCancelButton"), modifiedMenuButtonStyle))
						OnCancel();
				} GUILayout.EndArea();

				Rect area13 = new Rect(0.34f * area1.width, 0.8f * area1.height, 0.32f * area1.width, 0.2f * area1.height);
				GUILayout.BeginArea(area13); {
					if (selectedStateId < 0)
						GUI.enabled = false;

					if (GUILayout.Button(Language.GetText("SaveGameMenuDeleteGameButton"), modifiedMenuButtonStyle))
						OnDeleteGame();

					GUI.enabled = true;
				} GUILayout.EndArea();
				
				Rect area14 = new Rect(0.68f * area1.width, 0.8f * area1.height, 0.32f * area1.width, 0.2f * area1.height);
				GUILayout.BeginArea(area14); {
					if (newStateId.Trim().Length == 0 && selectedStateId < 0)
						GUI.enabled = false;

					if (GUILayout.Button(Language.GetText("SaveGameMenuSaveGameButton"), modifiedMenuButtonStyle))
						OnSaveGame();

					GUI.enabled = true;
				} GUILayout.EndArea();
			} GUILayout.EndArea();
		}
		
		private string FilterStateId(string stateId) {
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
			Game.CloseMenu();
		}

		private void OnDeleteGame() {
			string stateId = stateIds[selectedStateId];
			DeleteGameConfirmationMenuBehaviour.SetStateId(stateId);
			Game.OpenMenu("PauseDeleteGameConfirmationMenu");
		}
		
		private void OnSaveGame() {
			string stateId;
			if (selectedStateId < 0)
				stateId = newStateId.Trim();
			else
				stateId = stateIds[selectedStateId];

			if (stateIds.Contains(stateId)) {
				OverwriteGameConfirmationMenuBehaviour.SetStateId(stateId);
				Game.OpenMenu("OverwriteGameConfirmationMenu");
				return;
			}
			
			Game.SaveGame(stateId);
			Game.CloseMenu();
		}

	}
	
}
