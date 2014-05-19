using UnityEngine;

public class MainMenu : Menu {

	public Dialog quitDialog;
	public Menu optionsMenu;

	public void OnGUI() {
		string newGameButtonText = LanguageManager.GetText(G.TEXT_ID_MAIN_MENU_NEW_GAME_BUTTON);
		if (GUIManager.DrawButton(newGameButtonText, 0.5f * Screen.width, 0.2f * Screen.height, 120, 30))
			OnNewGameButtonClicked();

		string loadGameButtonText = LanguageManager.GetText(G.TEXT_ID_MAIN_MENU_LOAD_GAME_BUTTON);
		if (GUIManager.DrawButton(loadGameButtonText, 0.5f * Screen.width, 0.4f * Screen.height, 120, 30))
			OnLoadGameButtonClicked();

		string optionsButtonText = LanguageManager.GetText(G.TEXT_ID_MAIN_MENU_OPTIONS_BUTTON);
		if (GUIManager.DrawButton(optionsButtonText, 0.5f * Screen.width, 0.6f * Screen.height, 120, 30))
			OnOptionsButtonClicked();

		string quitButtonText = LanguageManager.GetText(G.TEXT_ID_MAIN_MENU_QUIT_BUTTON);
		if (GUIManager.DrawButton(quitButtonText, 0.5f * Screen.width, 0.8f * Screen.height, 120, 30))
			OnQuitButtonClicked();
	}

	private void OnLoadGameButtonClicked() {
		// TODO: on new game
		Debug.Log("TODO: on load game");
	}

	private void OnNewGameButtonClicked() {
		RoomManager.LoadRoom(G.ROOM_ID_LABORATORY);
	}
	
	private void OnOptionsButtonClicked() {
		// Shows the options menu
		GUIManager.ShowMenu(optionsMenu);
	}

	private void OnQuitButtonClicked() {
		// Shows the quit dialog
		GUIManager.ShowDialog(quitDialog);
	}
	
}
