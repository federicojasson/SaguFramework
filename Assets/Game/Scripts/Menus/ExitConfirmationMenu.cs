using UnityEngine;

public class ExitConfirmationMenu : Menu {
	
	public void OnGUI() {
		if (GUILayout.Button("Cancelar")) // TODO: use LanguageManager
			OnCancelButtonActuated();

		if (GUILayout.Button("Salir")) // TODO: use LanguageManager
			OnExitButtonActuated();
	}
	
	private void OnCancelButtonActuated() {
		GuiManager.CloseCurrentMenu();
	}
	
	private void OnExitButtonActuated() {
		GameManager.Exit();
	}
	
}
