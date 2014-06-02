//
// PauseMenu - Behaviour class
//
// This class implements the pause menu. It shows up everytime the user pauses the game.
//
// TODO: adjust sizes and positions to improve this menu
//
public class PauseMenu : Menu {

	public Dialog quitDialog;

	public void OnGUI() {
		string resumeButtonText = LanguageManager.GetText(G.TEXT_ID_PAUSE_MENU_RESUME_BUTTON);
		if (GUIManager.DrawButton(resumeButtonText, 0.5f, 0.2f, G.MENU_BUTTON_WIDTH, G.MENU_BUTTON_HEIGHT))
			OnResumeButtonActuated();

		string quitButtonText = LanguageManager.GetText(G.TEXT_ID_PAUSE_MENU_QUIT_BUTTON);
		if (GUIManager.DrawButton(quitButtonText, 0.5f, 0.8f, G.MENU_BUTTON_WIDTH, G.MENU_BUTTON_HEIGHT))
			OnQuitButtonActuated();
	}
	
	private void OnQuitButtonActuated() {
		GUIManager.ShowDialog(quitDialog);
	}

	private void OnResumeButtonActuated() {
		GameManager.ResumeGame();
	}

}
