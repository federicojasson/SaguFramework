using UnityEngine;

public class PauseMenu : Menu {

	public void OnGUI() {
		// TODO: draw the pause menu
		UnityEngine.Debug.Log("TODO: draw the pause menu");
		
		if (GUIManager.DrawButton("pause", 0.5f * Screen.width, 0.2f * Screen.height, 120, 30))
			GUIManager.HideMenu();
	}

}
