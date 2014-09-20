using SaguFramework;
using UnityEngine;

namespace EmergenciaQuimica {
	
	public sealed class ExitConfirmationMenuBehaviour : MenuBehaviour {

		public override void OnShowGui() {
			GUIStyle menuBoxStyle = Framework.GetStyle("MenuBox");
			GUIStyle menuButtonStyle = Framework.GetStyle("MenuButton");

			GameGui.BeginArea(0.25f, 0.35f, 0.5f, 0.3f); {
				GameGui.BeginArea(0f, 0f, 1f, 0.6f); {
					GUILayout.Box(Language.GetText("ExitConfirmationMenuBox"), menuBoxStyle, GUILayout.ExpandHeight(true));
				} GameGui.EndArea();

				GameGui.BeginArea(0f, 0.7f, 1f, 0.3f); {
					GameGui.BeginArea(0f, 0f, 0.49f, 1f); {
						if (GUILayout.Button(Language.GetText("ExitConfirmationMenuCancelButton"), menuButtonStyle))
							OnCancel();
					} GameGui.EndArea();

					GameGui.BeginArea(0.51f, 0f, 0.49f, 1f); {
						if (GUILayout.Button(Language.GetText("ExitConfirmationMenuExitButton"), menuButtonStyle))
							OnExit();
					} GameGui.EndArea();
				} GameGui.EndArea();
			} GameGui.EndArea();
		}
		
		private void OnCancel() {
			Framework.CloseMenu();
		}
		
		private void OnExit() {
			Framework.Exit();
		}

	}
	
}
