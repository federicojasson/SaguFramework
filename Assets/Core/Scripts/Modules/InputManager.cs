using UnityEngine;

public static class InputManager {

	private static bool enabled;
	private static Menu pauseMenu;

	public static void CheckInput() {
		if (enabled) {
			CheckKeyboardInput();
			CheckMouseInput();
		}
	}

	public static void Disable() {
		enabled = false;
	}
	
	public static void Enable() {
		enabled = true;
	}

	public static void Initialize(Menu pauseMenu) {
		InputManager.pauseMenu = pauseMenu;
		Enable();
	}

	private static void CheckKeyboardInput() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			// Escape key pressed
			Disable();
			GUIManager.ShowMenu(pauseMenu);
		}
	}
	
	private static void CheckMouseInput() {
		// TODO
	}

}
