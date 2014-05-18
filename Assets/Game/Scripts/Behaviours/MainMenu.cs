using UnityEngine;

public class MainMenu : Menu {

	public Menu optionsMenu;

	public void OnGUI() {
		string newGameButtonText = LanguageManager.GetText(G.TEXT_ID_MAIN_MENU_NEW_GAME_BUTTON);
		if (GUIManager.DrawButton(newGameButtonText, 0.5f, 0.2f, 120, 30))
			OnNewGameButtonClicked();

		string loadGameButtonText = LanguageManager.GetText(G.TEXT_ID_MAIN_MENU_LOAD_GAME_BUTTON);
		if (GUIManager.DrawButton(loadGameButtonText, 0.5f, 0.4f, 120, 30))
			OnLoadGameButtonClicked();

		string optionsButtonText = LanguageManager.GetText(G.TEXT_ID_MAIN_MENU_OPTIONS_BUTTON);
		if (GUIManager.DrawButton(optionsButtonText, 0.5f, 0.6f, 120, 30))
			OnOptionsButtonClicked();

		string quitButtonText = LanguageManager.GetText(G.TEXT_ID_MAIN_MENU_QUIT_BUTTON);
		if (GUIManager.DrawButton(quitButtonText, 0.5f, 0.8f, 120, 30))
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
		MenuManager.ShowMenu(optionsMenu);
	}

	private void OnQuitButtonClicked() {
		// Quits the application
		Application.Quit();
	}
	
}
