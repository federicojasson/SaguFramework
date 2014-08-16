using UnityEngine;

public class MainMenu : Menu {
	
	public void OnGUI() {
		// TODO: order this

		string newGameButtonText = "Nueva partida"; // TODO: use LanguageManager
		Rect newGameButtonRectangle = new Rect(128f, 64f, 160f, 64f);
		if (DrawingManager.DrawButton(newGameButtonText, newGameButtonRectangle))
			OnNewGameButtonActuated();

		string loadGameButtonText = "Cargar partida"; // TODO: use LanguageManager
		Rect loadGameButtonRectangle = new Rect(128f, 160f, 160f, 64f);
		if (DrawingManager.DrawButton(loadGameButtonText, loadGameButtonRectangle))
			OnLoadGameButtonActuated();

		string exitButtonText = "Salir"; // TODO: use LanguageManager
		Rect exitButtonRectangle = new Rect(128f, 256f, 160f, 64f);
		if (DrawingManager.DrawButton(exitButtonText, exitButtonRectangle))
			OnExitButtonActuated();
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
