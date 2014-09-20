using SaguFramework;
using UnityEngine;

namespace EmergenciaQuimica {
	
	public sealed class OverwriteGameConfirmationMenuBehaviour : MenuBehaviour {

		private static string stateId;

		public static void SetStateId(string stateId) {
			OverwriteGameConfirmationMenuBehaviour.stateId = stateId;
		}

		public override void OnShowGui() {
			GUIStyle menuBoxStyle = Framework.GetStyle("MenuBox");
			GUIStyle menuButtonStyle = Framework.GetStyle("MenuButton");

			Framework.BeginArea(0.25f, 0.35f, 0.5f, 0.3f); {
				Framework.BeginArea(0f, 0f, 1f, 0.6f); {
					GUILayout.Box(Framework.GetText("OverwriteGameConfirmationMenuBox"), menuBoxStyle, GUILayout.ExpandHeight(true));
				} Framework.EndArea();

				Framework.BeginArea(0f, 0.7f, 1f, 0.3f); {
					Framework.BeginArea(0f, 0f, 0.49f, 1f); {
						if (GUILayout.Button(Framework.GetText("OverwriteGameConfirmationMenuCancelButton"), menuButtonStyle))
							OnCancel();
					} Framework.EndArea();

					Framework.BeginArea(0.51f, 0f, 0.49f, 1f); {
						if (GUILayout.Button(Framework.GetText("OverwriteGameConfirmationMenuOverwriteGameButton"), menuButtonStyle))
							OnOverwriteGame();
					} Framework.EndArea();
				} Framework.EndArea();
			} Framework.EndArea();
		}
		
		private void OnCancel() {
			Framework.CloseMenu();
		}

		private void OnOverwriteGame() {
			Framework.SaveGame(stateId);
			Framework.CloseMenu();
			Framework.CloseMenu();
		}
		
	}
	
}
