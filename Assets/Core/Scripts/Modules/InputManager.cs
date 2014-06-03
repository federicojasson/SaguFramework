using UnityEngine;

//
// InputManager - Module class
//
// TODO: write class description
//
public static partial class InputManager {

	private static int mode;
	
	static InputManager() {
		mode = C.INPUT_MANAGER_MODE_DISABLED;
	}

	public static void CheckInput() {
		switch (mode) {
			case C.INPUT_MANAGER_MODE_DISABLED : {
				CheckInputModeDisabled();
				break;
			}
			
			case C.INPUT_MANAGER_MODE_PAUSE : {
				CheckInputModePause();
				break;
			}
			
			case C.INPUT_MANAGER_MODE_PLAY : {
				CheckInputModePlay();
				break;
			}
		}
	}
	
	public static void SetMode(int mode) {
		InputManager.mode = mode;

		switch (mode) {
			case C.INPUT_MANAGER_MODE_DISABLED : {
				SetModeDisabled();
				break;
			}
			
			case C.INPUT_MANAGER_MODE_PAUSE : {
				SetModePause();
				break;
			}
			
			case C.INPUT_MANAGER_MODE_PLAY : {
				SetModePlay();
				break;
			}
		}
	}

}
