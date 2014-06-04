using UnityEngine;

//
// InputManager.ModeDisabled - Module class
//
// TODO: write description
//
public static partial class InputManager {

	private static void CheckInputModeDisabled() {}

	private static void SetModeDisabled() {
		Texture2D cursorImage = Factory.GetCursorImageDisabled();
		GUIManager.SetCursorImage(cursorImage);
	}

}
