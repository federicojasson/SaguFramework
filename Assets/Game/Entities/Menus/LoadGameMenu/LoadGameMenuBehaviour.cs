using SaguFramework;
using UnityEngine;

namespace EmergenciaQuimica {
	
	public class LoadGameMenuBehaviour : MenuBehaviour {

		private string[] options;
		private int selectedOption;

		public void Awake() {
			options = State.GetStateIds();
			selectedOption = 0;
		}

		public override void OnShowGui() {
			selectedOption = GUILayout.SelectionGrid(selectedOption, options, 1);

			if (GUILayout.Button(Language.GetText("LoadGameMenuLoadGameButton")))
				OnLoadGame();

			if (GUILayout.Button(Language.GetText("LoadGameMenuCancelButton")))
				OnCancel();
		}
		
		private void OnCancel() {
			Game.CloseMenu();
		}

		private void OnLoadGame() {
			string stateId = options[selectedOption];
			Game.LoadGame(stateId, "Information");
		}
		
	}
	
}
