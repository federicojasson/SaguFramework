using UnityEngine;

//
// InputManager - Module class
//
// TODO: write class description
//
public static class InputManager {

	private static int mode;

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
	
	public static void SetMode(int mode) {
		InputManager.mode = mode;
	}

	private static void CheckModePauseKeyboardInput() {
		if (Input.GetKeyDown(KeyCode.Escape))
			// Escape key pressed
			GameManager.ResumeGame();
	}

	private static void CheckModePlayKeyboardInput() {
		if (Input.GetKeyDown(KeyCode.Escape))
			// Escape key pressed
			GameManager.PauseGame();
	}
	
	private static void CheckModePlayMouseInput() {
		// TODO
	}

}
