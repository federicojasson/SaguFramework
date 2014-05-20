using UnityEngine;

public class OptionsMenu : Menu {

	public void OnGUI() {
		// TODO: draw the options menu

		if (GUIManager.DrawButton("test (go back)", 0.5f * Screen.width, 0.2f * Screen.height, 120, 30))
			GUIManager.HideMenu();
	}

}
