using SaguFramework;
using UnityEngine;

namespace EmergenciaQuimica {

	public class MainMenuBehaviour : MenuBehaviour {

		private bool isLocked;

		public void Start() {
			isLocked = false;
		}

		public override void OnShowing() {
			GUILayout.BeginArea(UtilityManager.GetGuiRectangle(UtilityManager.GetGameRectangleInScreen()));

			if (GUILayout.Button("Nueva partida")) // TODO: use LanguageManager
				OnNewGameButtonActuated();
			
			if (GUILayout.Button("Cargar partida")) // TODO: use LanguageManager
				OnLoadGameButtonActuated();
			
			if (GUILayout.Button("Opciones")) // TODO: use LanguageManager
				OnOptionsButtonActuated();
			
			if (GUILayout.Button("Salir")) // TODO: use LanguageManager
				OnExitButtonActuated();

			GUILayout.EndArea();
		}

		private void OnExitButtonActuated() {
			if (! isLocked)
				GameManager.OpenMenu("ExitConfirmationMenu");
		}
		
		private void OnLoadGameButtonActuated() {
			if (! isLocked)
				GameManager.OpenMenu("LoadGameMenu");
		}
		
		private void OnNewGameButtonActuated() {
			if (! isLocked) {
				// Locks the menu
				isLocked = true;

				// Starts a new game
				GameManager.NewGame(true);
			}
		}
		
		private void OnOptionsButtonActuated() {
			if (! isLocked)
				GameManager.OpenMenu("OptionsMenu");
		}
		
	}

}
