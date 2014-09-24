using SaguFramework;
using UnityEngine;

namespace EmergenciaQuimica {
	
	public sealed class LoadGameConfirmationMenuBehaviour : MenuBehaviour {

		private static string stateId;

		public static void SetStateId(string stateId) {
			LoadGameConfirmationMenuBehaviour.stateId = stateId;
		}

		public override void OnShowGui() {
			GUIStyle menuBoxStyle = Framework.GetStyle("MenuBox");
			GUIStyle menuButtonStyle = Framework.GetStyle("MenuButton");

			Framework.BeginArea(0.25f, 0.35f, 0.5f, 0.3f); {
				Framework.BeginArea(0f, 0f, 1f, 0.6f); {
					GUILayout.Box(Framework.GetText("LoadGameConfirmationMenuBox"), menuBoxStyle, GUILayout.ExpandHeight(true));
				} Framework.EndArea();

				Framework.BeginArea(0f, 0.7f, 1f, 0.3f); {
					Framework.BeginArea(0f, 0f, 0.49f, 1f); {
						if (GUILayout.Button(Framework.GetText("LoadGameConfirmationMenuCancelButton"), menuButtonStyle))
							OnCancel();
					} Framework.EndArea();

					Framework.BeginArea(0.51f, 0f, 0.49f, 1f); {
						if (GUILayout.Button(Framework.GetText("LoadGameConfirmationMenuLoadGameButton"), menuButtonStyle))
							OnLoadGame();
					} Framework.EndArea();
				} Framework.EndArea();
			} Framework.EndArea();
		}
		
		private void OnCancel() {
			Framework.CloseMenu();
		}

		private void OnLoadGame() {
			Framework.LoadGame(stateId, "Information");
		}
		
	}
	
}
