public class PauseMenu : Menu {

	public void OnGUI() {
		// TODO: draw the pause menu
		UnityEngine.Debug.Log("TODO: draw the pause menu");
		
		if (GUIManager.DrawButton("pause", 0.5f, 0.2f, 120, 30))
			MenuManager.HideMenu();
	}

}
