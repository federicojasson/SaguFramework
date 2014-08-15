using UnityEngine;

public class MainMenu : Menu {
	
	public void OnGUI() {
		// TODO: order this

		string exitButtonText = "Salir"; // TODO: use LanguageManager
		Rect exitButtonRectangle = new Rect(64f, 64f, 64f, 64f);
		if (GuiManager.DrawButton(exitButtonText, exitButtonRectangle))
			OnExitButtonActuated();
	}

	private void OnExitButtonActuated() {
		// TODO

	}
	
}
