using UnityEngine;

//
// InputManager.ModePause - Module class
//
// TODO: write description
//
public static partial class InputManager {

	private static void CheckInputModePause() {
		CheckKeyboardModePause();
	}

	private static void CheckKeyboardModePause() {
		if (Input.GetKeyDown(KeyCode.Escape))
			// Escape key pressed
			GameManager.ResumeGame();
	}

	private static void SetModePause() {
		Texture2D cursorImage = Factory.GetCursorImagePauseStatic();
		GUIManager.SetCursorImage(cursorImage);
	}

}
