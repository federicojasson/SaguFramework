using SaguFramework;
using UnityEngine;

namespace EmergenciaQuimica {
	
	public sealed class LoadGameMenuBehaviour : MenuBehaviour {

		private Vector2 scrollPosition;
		private int selectedStateId;
		private string[] stateIds;
		private int stateLastCount;

		public void Awake() {
			stateLastCount = -1;
		}

		public void OnEnable() {
			int auxiliar = stateLastCount;
			stateIds = Framework.GetStateIds();
			stateLastCount = stateIds.Length;

			if (stateLastCount != auxiliar)
				selectedStateId = -1;
		}

		public override void OnShowGui() {
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
						selectedStateId = GUILayout.SelectionGrid(selectedStateId, stateIds, 1, menuSelectionGridStyle);
					} GUILayout.EndScrollView();
				} Framework.EndArea();

				Framework.BeginArea(0f, 0.8f, 0.32f, 0.2f); {
					if (GUILayout.Button(Framework.GetText("LoadGameMenuCancelButton"), menuButtonStyle))
						OnCancel();
				} Framework.EndArea();

				Framework.BeginArea(0.34f, 0.8f, 0.32f, 0.2f); {
					if (selectedStateId < 0)
						GUI.enabled = false;
					
					if (GUILayout.Button(Framework.GetText("LoadGameMenuDeleteGameButton"), menuButtonStyle))
						OnDeleteGame();
					
					GUI.enabled = true;
				} Framework.EndArea();

				Framework.BeginArea(0.68f, 0.8f, 0.32f, 0.2f); {
					if (selectedStateId < 0)
						GUI.enabled = false;

					if (GUILayout.Button(Framework.GetText("LoadGameMenuLoadGameButton"), menuButtonStyle))
						OnLoadGame();

					GUI.enabled = true;
				} Framework.EndArea();
			} Framework.EndArea();
		}

		private void OnDeleteGame() {
			string stateId = stateIds[selectedStateId];
			DeleteGameConfirmationMenuBehaviour.SetStateId(stateId);

			if (Framework.IsMainMenuOpen())
				Framework.OpenMenu("MainDeleteGameConfirmationMenu");
			else
				Framework.OpenMenu("PauseDeleteGameConfirmationMenu");
		}
		
		private void OnCancel() {
			Framework.CloseMenu();
		}

		private void OnLoadGame() {
			string stateId = stateIds[selectedStateId];
			Framework.LoadGame(stateId, "Information");
		}
		
	}
	
}
