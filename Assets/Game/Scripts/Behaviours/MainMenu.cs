using UnityEngine;

//
// MainMenu - Behaviour class
//
// This class implements the main menu. It shows up only when the game application is started.
//
// TODO: adjust sizes and positions to improve this menu
//
public class MainMenu : Menu {
	
	public Menu optionsMenu;
	public Dialog quitDialog;

	public void OnGUI() {
		string newGameButtonText = LanguageManager.GetText(G.TEXT_ID_MAIN_MENU_NEW_GAME_BUTTON);
		if (GUIManager.DrawButton(newGameButtonText, 0.5f * Screen.width, 0.2f * Screen.height, G.MENU_BUTTON_WIDTH, G.MENU_BUTTON_HEIGHT))
			OnNewGameButtonActuated();

		string loadGameButtonText = LanguageManager.GetText(G.TEXT_ID_MAIN_MENU_LOAD_GAME_BUTTON);
		if (GUIManager.DrawButton(loadGameButtonText, 0.5f * Screen.width, 0.4f * Screen.height, G.MENU_BUTTON_WIDTH, G.MENU_BUTTON_HEIGHT))
			OnLoadGameButtonActuated();

		string optionsButtonText = LanguageManager.GetText(G.TEXT_ID_MAIN_MENU_OPTIONS_BUTTON);
		if (GUIManager.DrawButton(optionsButtonText, 0.5f * Screen.width, 0.6f * Screen.height, G.MENU_BUTTON_WIDTH, G.MENU_BUTTON_HEIGHT))
			OnOptionsButtonActuated();

		string quitButtonText = LanguageManager.GetText(G.TEXT_ID_MAIN_MENU_QUIT_BUTTON);
		if (GUIManager.DrawButton(quitButtonText, 0.5f * Screen.width, 0.8f * Screen.height, G.MENU_BUTTON_WIDTH, G.MENU_BUTTON_HEIGHT))
			OnQuitButtonActuated();
	}

	private void OnLoadGameButtonActuated() {
		GameManager.LoadGame();
	}

	private void OnNewGameButtonActuated() {
		GameManager.LoadNewGame();
	}
	
	private void OnOptionsButtonActuated() {
		GUIManager.ShowMenu(optionsMenu);
	}

	private void OnQuitButtonActuated() {
		GUIManager.ShowDialog(quitDialog);
	}
	
}
