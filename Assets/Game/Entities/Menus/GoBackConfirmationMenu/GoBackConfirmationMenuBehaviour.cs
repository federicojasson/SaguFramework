using SaguFramework;
using UnityEngine;

namespace EmergenciaQuimica {
	
	public sealed class GoBackConfirmationMenuBehaviour : MenuBehaviour {
		
		private bool isEnabled;
		
		public void Awake() {
			isEnabled = true;
		}
		
		public override void OnShowGui() {
			if (isEnabled)
				GUI.enabled = true;
			else
				GUI.enabled = false;

			GUIStyle menuBoxStyle = Framework.GetStyle("MenuBox");
			GUIStyle menuButtonStyle = Framework.GetStyle("MenuButton");

			GameGui.BeginArea(0.25f, 0.35f, 0.5f, 0.3f); {
				GameGui.BeginArea(0f, 0f, 1f, 0.6f); {
					GUILayout.Box(Language.GetText("GoBackConfirmationMenuBox"), menuBoxStyle, GUILayout.ExpandHeight(true));
				} GameGui.EndArea();

				GameGui.BeginArea(0f, 0.7f, 1f, 0.3f); {
					GameGui.BeginArea(0f, 0f, 0.49f, 1f); {
						if (GUILayout.Button(Language.GetText("GoBackConfirmationMenuCancelButton"), menuButtonStyle))
							OnCancel();
					} GameGui.EndArea();

					GameGui.BeginArea(0.51f, 0f, 0.49f, 1f); {
						if (GUILayout.Button(Language.GetText("GoBackConfirmationMenuGoBackButton"), menuButtonStyle))
							OnGoBack();
					} GameGui.EndArea();
				} GameGui.EndArea();
			} GameGui.EndArea();
		}
		
		private void OnCancel() {
			Framework.CloseMenu();
		}
		
		private void OnGoBack() {
			isEnabled = false;
			Framework.OpenMainMenu();
		}
		
	}
	
}
