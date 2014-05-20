using UnityEngine;

public class PauseMenu : Menu {

	public void OnGUI() {
		string resumeButtonText = LanguageManager.GetText(G.TEXT_ID_PAUSE_MENU_RESUME_BUTTON);
		if (GUIManager.DrawButton(resumeButtonText, 0.5f * Screen.width, 0.2f * Screen.height, G.MENU_BUTTON_WIDTH, G.MENU_BUTTON_HEIGHT))
			OnResumeButtonActuated();
	}

	private void OnResumeButtonActuated() {
		// Hides the menu
		GUIManager.HideMenu();
	}

}
