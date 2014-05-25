using UnityEngine;

public class PauseMenu : Menu {

	public Dialog quitDialog;

	public void OnGUI() {
		string resumeButtonText = LanguageManager.GetText(G.TEXT_ID_PAUSE_MENU_RESUME_BUTTON);
		if (GUIManager.DrawButton(resumeButtonText, 0.5f * Screen.width, 0.2f * Screen.height, G.MENU_BUTTON_WIDTH, G.MENU_BUTTON_HEIGHT))
			OnResumeButtonActuated();

		string quitButtonText = LanguageManager.GetText(G.TEXT_ID_PAUSE_MENU_QUIT_BUTTON);
		if (GUIManager.DrawButton(quitButtonText, 0.5f * Screen.width, 0.8f * Screen.height, G.MENU_BUTTON_WIDTH, G.MENU_BUTTON_HEIGHT))
			OnQuitButtonActuated();
	}
	
	private void OnQuitButtonActuated() {
		// Shows the quit dialog
		GUIManager.ShowDialog(quitDialog);
	}

	private void OnResumeButtonActuated() {
		// Hides the menu
		GUIManager.HideMenu();

		// Sets the input manager in play mode
		InputManager.SetMode(C.INPUT_MANAGER_MODE_PLAY);
	}

}
