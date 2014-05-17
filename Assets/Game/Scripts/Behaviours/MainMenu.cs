using UnityEngine;

public class MainMenu : MonoBehaviour {

	public void OnGUI() {
		// TODO: draw menu
		Debug.Log("TODO: draw menu");

		string newGameButtonText = LanguageManager.GetText(G.TEXT_ID_MAIN_MENU_NEW_GAME_BUTTON);
		if (GUIManager.DrawButton(newGameButtonText, 0.5f, 0.33f, 120, 30))
			OnNewGameButtonClicked();

		string loadGameButtonText = LanguageManager.GetText(G.TEXT_ID_MAIN_MENU_LOAD_GAME_BUTTON);
		if (GUIManager.DrawButton(loadGameButtonText, 0.5f, 0.66f, 120, 30))
			OnLoadGameButtonClicked();
	}

	private void OnLoadGameButtonClicked() {
		// TODO: on new game
		Debug.Log("TODO: on load game");
	}

	private void OnNewGameButtonClicked() {
		// TODO: on new game
		Debug.Log("TODO: on new game");
	}
	
}
