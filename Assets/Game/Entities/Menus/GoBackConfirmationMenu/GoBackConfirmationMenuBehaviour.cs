﻿using SaguFramework;
using UnityEngine;

namespace EmergenciaQuimica {
	
	public class GoBackConfirmationMenuBehaviour : MenuBehaviour {
		
		private bool isEnabled;
		
		public void Awake() {
			isEnabled = true;
		}
		
		public override void OnShowGui() {
			if (isEnabled)
				GUI.enabled = true;
			else
				GUI.enabled = false;

			
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
					GUILayout.Box(Language.GetText("GoBackConfirmationMenuBox"), modifiedMenuBoxStyle, GUILayout.ExpandHeight(true));
				} GUILayout.EndArea();

				Rect area01 = new Rect(0f, 0.7f * area0.height, area0.width, 0.3f * area0.height);
				GUILayout.BeginArea(area01); {
					Rect area010 = new Rect(0f, 0f, 0.49f * area01.width, area01.height);
					GUILayout.BeginArea(area010); {
						if (GUILayout.Button(Language.GetText("GoBackConfirmationMenuCancelButton"), modifiedMenuButtonStyle))
							OnCancel();
					} GUILayout.EndArea();
					
					Rect area011 = new Rect(0.51f * area01.width, 0f, 0.49f * area01.width, area01.height);
					GUILayout.BeginArea(area011); {
						if (GUILayout.Button(Language.GetText("GoBackConfirmationMenuGoBackButton"), modifiedMenuButtonStyle))
							OnGoBack();
					} GUILayout.EndArea();
				} GUILayout.EndArea();
			} GUILayout.EndArea();
		}
		
		private void OnCancel() {
			Game.CloseMenu();
		}
		
		private void OnGoBack() {
			isEnabled = false;
			Game.OpenMainMenu();
		}
		
	}
	
}
