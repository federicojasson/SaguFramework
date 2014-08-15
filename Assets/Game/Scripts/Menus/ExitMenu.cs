using UnityEngine;

public class ExitMenu : Menu {
	
	public void OnGUI() {
		// TODO: order this

		string cancelButtonText = "Cancelar"; // TODO: use LanguageManager
		Rect cancelButtonRectangle = new Rect(64f, 64f, 64f, 64f);
		if (DrawingManager.DrawButton(cancelButtonText, cancelButtonRectangle))
			OnCancelButtonActuated();

		string exitButtonText = "Salir"; // TODO: use LanguageManager
		Rect exitButtonRectangle = new Rect(160f, 64f, 64f, 64f);
		if (DrawingManager.DrawButton(exitButtonText, exitButtonRectangle))
			OnExitButtonActuated();
	}

	private void OnCancelButtonActuated() {
		MenuManager.CloseCurrentMenu();
	}

	private void OnExitButtonActuated() {
		// TODO: use a manager
		Application.Quit();
	}
	
}
