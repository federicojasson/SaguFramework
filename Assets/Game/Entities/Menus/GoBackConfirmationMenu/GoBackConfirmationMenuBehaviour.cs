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

			Framework.BeginArea(0.25f, 0.35f, 0.5f, 0.3f); {
				Framework.BeginArea(0f, 0f, 1f, 0.6f); {
					GUILayout.Box(Framework.GetText("GoBackConfirmationMenuBox"), menuBoxStyle, GUILayout.ExpandHeight(true));
				} Framework.EndArea();

				Framework.BeginArea(0f, 0.7f, 1f, 0.3f); {
					Framework.BeginArea(0f, 0f, 0.49f, 1f); {
						if (GUILayout.Button(Framework.GetText("GoBackConfirmationMenuCancelButton"), menuButtonStyle))
							OnCancel();
					} Framework.EndArea();

					Framework.BeginArea(0.51f, 0f, 0.49f, 1f); {
						if (GUILayout.Button(Framework.GetText("GoBackConfirmationMenuGoBackButton"), menuButtonStyle))
							OnGoBack();
					} Framework.EndArea();
				} Framework.EndArea();
			} Framework.EndArea();
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
