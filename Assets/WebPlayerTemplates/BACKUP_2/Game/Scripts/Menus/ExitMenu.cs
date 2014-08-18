using UnityEngine;

public class ExitMenu : Menu {
	
	public void OnGUI() {
		base.OnGUI();

		GuiManager.BeginArea(GuiManager.Center, GuiManager.Middle, 0.3f, 0.1f);

		GuiManager.BeginArea(GuiManager.Left, GuiManager.Middle, 0.45f, 1f);
		if (GuiManager.Button("Cancelar")) // TODO: use LanguageManager
			OnCancelButtonActuated();
		GuiManager.EndArea();

		GuiManager.BeginArea(GuiManager.Right, GuiManager.Middle, 0.45f, 1f);
		if (GuiManager.Button("Salir")) // TODO: use LanguageManager
			OnExitButtonActuated();
		GuiManager.EndArea();

		GuiManager.EndArea();
	}

	private void OnCancelButtonActuated() {
		MenuManager.CloseCurrentMenu();
	}

	private void OnExitButtonActuated() {
		// TODO: use a manager
		Application.Quit();
	}
	
}
