using UnityEngine;

public static class InputManager {

	private static int mode;
	private static Menu pauseMenu;

	public static void CheckInput() {
		switch (mode) {
			case C.INPUT_MANAGER_MODE_PAUSE : {
				CheckModePauseKeyboardInput();
				break;
			}
			
			case C.INPUT_MANAGER_MODE_PLAY : {
				CheckModePlayKeyboardInput();
				CheckModePlayMouseInput();
				break;
			}
		}
	}

	public static void Initialize(Menu pauseMenu) {
		InputManager.mode = C.INPUT_MANAGER_MODE_DISABLED;
		InputManager.pauseMenu = pauseMenu;
	}
	
	public static void SetMode(int mode) {
		InputManager.mode = mode;
	}

	private static void CheckModePauseKeyboardInput() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			// Escape key pressed

			// Hides all opened menus and dialogs
			GUIManager.HideAll();

			// Sets the play mode
			mode = C.INPUT_MANAGER_MODE_PLAY;
		}
	}

	private static void CheckModePlayKeyboardInput() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			// Escape key pressed

			// Sets the pause mode
			mode = C.INPUT_MANAGER_MODE_PAUSE;

			// Shows the pause menu
			GUIManager.ShowMenu(pauseMenu);
		}
	}
	
	private static void CheckModePlayMouseInput() {
		// TODO
	}

}
