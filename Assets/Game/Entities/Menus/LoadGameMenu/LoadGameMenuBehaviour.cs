using SaguFramework;
using UnityEngine;

namespace EmergenciaQuimica {
	
	public class LoadGameMenuBehaviour : MenuBehaviour {

		private string[] stateIds;
		private int selectedStateId;

		public void Awake() {
			stateIds = State.GetStateIds();
			selectedStateId = -1;
		}

		public override void OnShowGui() {
			GUIStyle menuButtonStyle = GUI.skin.GetStyle("MenuButton");
			GUIStyle modifiedMenuButtonStyle = Utilities.GetRelativeStyle(menuButtonStyle);

			GUIStyle menuSelectionGridStyle = GUI.skin.GetStyle("MenuSelectionGrid");
			GUIStyle modifiedMenuSelectionGridStyle = Utilities.GetRelativeStyle(menuSelectionGridStyle);

			GUIStyle menuTitleStyle = GUI.skin.GetStyle("MenuTitle");
			GUIStyle modifiedMenuTitleStyle = Utilities.GetRelativeStyle(menuTitleStyle);

			float gameWidth = Geometry.GetGameWidthInPixels();
			float gameHeight = Geometry.GetGameHeightInPixels();

			Rect area0 = new Rect(0.05f * gameWidth, 0.05f * gameHeight, 0.9f * gameWidth, 0.1f * gameHeight);
			GUILayout.BeginArea(area0); {
				GUILayout.Label(Language.GetText("LoadGameMenuTitleLabel"), modifiedMenuTitleStyle);
			} GUILayout.EndArea();

			Rect area1 = new Rect(0.1f * gameWidth, 0.18f * gameHeight, 0.8f * gameWidth, 0.77f * gameHeight);
			GUILayout.BeginArea(area1); {
				Rect area10 = new Rect(0f, 0f, area1.width, 0.75f * area1.height);
				GUILayout.BeginArea(area10); {
					selectedStateId = GUILayout.SelectionGrid(selectedStateId, stateIds, 1, modifiedMenuSelectionGridStyle);
				} GUILayout.EndArea();

				Rect area11 = new Rect(0f, 0.8f * area1.height, 0.45f * area1.width, 0.2f * area1.height);
				GUILayout.BeginArea(area11); {
					if (GUILayout.Button(Language.GetText("LoadGameMenuCancelButton"), modifiedMenuButtonStyle))
						OnCancel();
				} GUILayout.EndArea();
				
				Rect area12 = new Rect(0.51f * area1.width, 0.8f * area1.height, 0.49f * area1.width, 0.2f * area1.height);
				GUILayout.BeginArea(area12); {
					if (selectedStateId < 0)
						GUI.enabled = false;

					if (GUILayout.Button(Language.GetText("LoadGameMenuLoadGameButton"), modifiedMenuButtonStyle))
						OnLoadGame();

					GUI.enabled = true;
				} GUILayout.EndArea();
			} GUILayout.EndArea();
		}
		
		private void OnCancel() {
			Game.CloseMenu();
		}

		private void OnLoadGame() {
			string stateId = stateIds[selectedStateId];
			Game.LoadGame(stateId, "Information");
		}
		
	}
	
}
