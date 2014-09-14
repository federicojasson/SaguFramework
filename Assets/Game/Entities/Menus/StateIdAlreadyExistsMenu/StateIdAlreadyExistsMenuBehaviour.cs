using SaguFramework;
using UnityEngine;

namespace EmergenciaQuimica {
	
	public class StateIdAlreadyExistsMenuBehaviour : MenuBehaviour {
		
		public override void OnShowGui() {
			GUIStyle menuBoxStyle = GUI.skin.GetStyle("MenuBox");
			GUIStyle modifiedMenuBoxStyle = Utilities.GetRelativeStyle(menuBoxStyle);
			
			GUIStyle menuButtonStyle = GUI.skin.GetStyle("MenuButton");
			GUIStyle modifiedMenuButtonStyle = Utilities.GetRelativeStyle(menuButtonStyle);
			
			float gameWidth = Geometry.GetGameWidthInPixels();
			float gameHeight = Geometry.GetGameHeightInPixels();
			
			Rect area0 = new Rect(0.25f * gameWidth, 0.35f * gameHeight, 0.5f * gameWidth, 0.3f * gameHeight);
			GUILayout.BeginArea(area0); {
				Rect area00 = new Rect(0f, 0f, area0.width, 0.6f * area0.height);
				GUILayout.BeginArea(area00); {
					GUILayout.Box(Language.GetText("StateIdAlreadyExistsMenuBox"), modifiedMenuBoxStyle, GUILayout.ExpandHeight(true));
				} GUILayout.EndArea();
				
				Rect area01 = new Rect(0.51f * area0.width, 0.7f * area0.height, 0.49f * area0.width, 0.3f * area0.height);
				GUILayout.BeginArea(area01); {
					if (GUILayout.Button(Language.GetText("StateIdAlreadyExistsMenuAcceptButton"), modifiedMenuButtonStyle))
						OnAccept();
				} GUILayout.EndArea();
			} GUILayout.EndArea();
		}
		
		private void OnAccept() {
			Game.CloseMenu();
		}
		
	}
	
}
