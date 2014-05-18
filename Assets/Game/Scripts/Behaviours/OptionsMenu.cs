public class OptionsMenu : Menu {

	public void OnGUI() {
		// TODO: draw the options menu
		UnityEngine.Debug.Log("TODO: draw the options menu");

		if (GUIManager.DrawButton("test (go back)", 0.5f, 0.2f, 120, 30))
			MenuManager.HideMenu();
	}

}
