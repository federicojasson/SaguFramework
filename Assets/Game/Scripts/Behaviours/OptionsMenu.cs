using UnityEngine;

//
// OptionsMenu - Behaviour class
//
// This class implements the options menu. It allows the user to change the game configurations.
//
// TODO: add logic and options
// TODO: adjust sizes and positions to improve this menu
//
public class OptionsMenu : Menu {

	public void OnGUI() {
		string cancelButtonText = LanguageManager.GetText(G.TEXT_ID_OPTIONS_MENU_CANCEL_BUTTON);
		if (GUIManager.DrawButton(cancelButtonText, 0.5f * Screen.width, 0.8f * Screen.height, G.MENU_BUTTON_WIDTH, G.MENU_BUTTON_HEIGHT))
			OnCancelButtonActuated();
	}

	private void OnCancelButtonActuated() {
		GUIManager.HideMenu();
	}

}
