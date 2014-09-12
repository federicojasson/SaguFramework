using SaguFramework;
using System;
using System.Linq;
using UnityEngine;

namespace EmergenciaQuimica {
	
	public class SaveGameMenuBehaviour : MenuBehaviour {
		
		private string newStateId;
		private string[] options;
		private int selectedOption;
		private string[] stateIds;

		public void Awake() {
			newStateId = Language.GetText("SaveGameMenuNewStateIdTextField");

			stateIds = State.GetStateIds();

			options = new string[stateIds.Length + 1];
			options[0] = Language.GetText("SaveGameMenuNewStateIdButton");
			for (int i = 1; i < options.Length; i++)
				options[i] = stateIds[i - 1];

			selectedOption = 0;
		}

		public override void OnShowGui() {
			selectedOption = GUILayout.SelectionGrid(selectedOption, options, 1);

			if (selectedOption != 0)
				GUI.enabled = false;

			newStateId = FilterStateId(GUILayout.TextField(newStateId));
			GUI.enabled = true;

			if (GUILayout.Button(Language.GetText("SaveGameMenuSaveGameButton")))
				OnSaveGame();

			if (GUILayout.Button(Language.GetText("SaveGameMenuCancelButton")))
				OnCancel();
		}

		private string FilterStateId(string stateId) {
			string temporalStateId = stateId.Trim().ToUpperInvariant();
			string filteredStateId = "";

			for (int i = 0; i < temporalStateId.Length; i++) {
				char character = temporalStateId[i];

				if (character >= 'A' && character <= 'Z') {
					filteredStateId += character;
					continue;
				}

				if (character >= '0' && character <= '9') {
					filteredStateId += character;
					continue;
				}

				switch (character) {
					case ' ' :
					case '_' :
					case '-' : {
						filteredStateId += character;
						continue;
					}
				}
			}

			return filteredStateId;
		}

		private void OnCancel() {
			Game.CloseMenu();
		}

		private void OnSaveGame() {
			string stateId;
			if (selectedOption == 0) {
				stateId = newStateId;

				if (stateIds.Contains(newStateId)) {
					Game.OpenMenu("StateIdAlreadyExistsMenu");
					return;
				}
			} else
				stateId = stateIds[selectedOption - 1];

			Game.SaveGame(stateId);
			Game.CloseMenu();
		}
		
	}
	
}
