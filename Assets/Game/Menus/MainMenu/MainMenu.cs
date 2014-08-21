using UnityEngine;

public class MainMenu : Menu {
	
	public void OnGUI() {
		if (GUILayout.Button("Nueva partida")) // TODO: use LanguageManager
			OnNewGameButtonActuated();

		if (GUILayout.Button("Cargar partida")) // TODO: use LanguageManager
			OnLoadGameButtonActuated();

		if (GUILayout.Button("Opciones")) // TODO: use LanguageManager
			OnOptionsButtonActuated();

		if (GUILayout.Button("Salir")) // TODO: use LanguageManager
			OnExitButtonActuated();
	}
	
	private void OnExitButtonActuated() {
		GuiManager.OpenMenu("ExitConfirmationMenu");
	}
	
	private void OnLoadGameButtonActuated() {
		GuiManager.OpenMenu("LoadGameMenu");
	}
	
	private void OnNewGameButtonActuated() {
		GameManager.NewGame(true);
	}
	
	private void OnOptionsButtonActuated() {
		GuiManager.OpenMenu("OptionsMenu");
	}
	
}
