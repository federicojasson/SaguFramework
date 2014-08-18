using UnityEngine;

public class MainMenu : Menu {
	
	public void OnGUI() {
		base.OnGUI();

		GuiManager.BeginArea(0.25f, 0.5f, 0.3f, 0.8f);
		
		GuiManager.BeginArea(0.5f, 0.2f, 1f, 0.2f);
		if (GuiManager.Button("Nueva partida")) // TODO: use LanguageManager
			OnNewGameButtonActuated();
		GuiManager.EndArea();
		
		GuiManager.BeginArea(0.5f, 0.5f, 1f, 0.2f);
		if (GuiManager.Button("Cargar partida")) // TODO: use LanguageManager
			OnLoadGameButtonActuated();
		GuiManager.EndArea();
		
		GuiManager.BeginArea(0.5f, 0.8f, 1f, 0.2f);
		if (GuiManager.Button("Salir")) // TODO: use LanguageManager
			OnExitButtonActuated();
		GuiManager.EndArea();
		
		GuiManager.EndArea();
	}

	private void OnExitButtonActuated() {
		MenuManager.OpenMenu("ExitMenu");
	}

	private void OnLoadGameButtonActuated() {
		MenuManager.OpenMenu("LoadMenu");
	}

	private void OnNewGameButtonActuated() {
		StateManager.LoadInitialState();
	}
	
}
