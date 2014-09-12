using SaguFramework;
using UnityEngine;

namespace EmergenciaQuimica {
	
	public class ExitConfirmationMenuBehaviour : MenuBehaviour {
		
		public override void OnShowGui() {
			GUIStyle menuButtonStyle = GUI.skin.GetStyle("MenuButton");
			GUIStyle menuLabelStyle = GUI.skin.GetStyle("MenuLabel");
			float gameWidth = Geometry.GetGameWidthInPixels();
			float gameHeight = Geometry.GetGameHeightInPixels();

			Rect area0 = new Rect(0.25f * gameWidth, 0.4f * gameHeight, 0.5f * gameWidth, 0.2f * gameHeight);
			GUILayout.BeginArea(area0); {
				Rect area1 = new Rect(0f, 0f, area0.width, 0.6f * area0.height);
				GUILayout.BeginArea(area1); {
					GUILayout.Label(Language.GetText("ExitConfirmationMenuLabel"), menuLabelStyle, GUILayout.ExpandHeight(true));
				}
				GUILayout.EndArea();

				Rect area2 = new Rect(0f, 0.6f * area0.height, 0.5f * area0.width, 0.4f * area0.height);
				GUILayout.BeginArea(area2); {
					if (GUILayout.Button(Language.GetText("ExitConfirmationMenuExitButton"), menuButtonStyle))
						OnExit();
				}
				GUILayout.EndArea();

				Rect area3 = new Rect(0.5f * area0.width, 0.6f * area0.height, 0.5f * area0.width, 0.4f * area0.height);
				GUILayout.BeginArea(area3); {
					if (GUILayout.Button(Language.GetText("ExitConfirmationMenuCancelButton"), menuButtonStyle))
						OnCancel();
				}
				GUILayout.EndArea();
			}
			GUILayout.EndArea();
		}
		
		private void OnCancel() {
			Game.CloseMenu();
		}
		
		private void OnExit() {
			Game.Exit();
		}

	}
	
}
