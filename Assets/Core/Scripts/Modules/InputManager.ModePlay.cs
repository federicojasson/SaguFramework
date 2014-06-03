using UnityEngine;

//
// InputManager.ModePlay - Module class
//
// TODO: write description
//
public static partial class InputManager {

	public static void NotifyOnMouseEnter(InteractiveObject interactiveObject) {
		if (mode == C.INPUT_MANAGER_MODE_PLAY)
			interactiveObject.DoFocus();
	}
	
	public static void NotifyOnMouseExit(InteractiveObject interactiveObject) {
		if (mode == C.INPUT_MANAGER_MODE_PLAY)
			interactiveObject.DoDefocus();
	}

	public static void NotifySetOrder() {
		if (mode == C.INPUT_MANAGER_MODE_PLAY) {
			int currentOrder = OrderManager.GetCurrentOrder();
			SetOrderCursorImage(currentOrder);
		}
	}

	private static void CheckInputModePlay() {
		CheckKeyboardModePlay();
		CheckMouseModePlay();
	}

	private static void CheckKeyboardModePlay() {
		if (Input.GetKeyDown(KeyCode.Escape))
			// Escape key pressed
			GameManager.PauseGame();
	}
	
	private static void CheckMouseModePlay() {
		if (Input.GetMouseButtonDown(0))
			// Left mouse button pressed
			OrderManager.ExecuteCurrentOrder();

		if (Input.GetMouseButtonDown(1))
			// Right mouse button pressed
			OrderManager.SetNextRotativeOrder();
	}
	
	private static void SetModePlay() {
		int currentOrder = OrderManager.GetCurrentOrder();
		SetOrderCursorImage(currentOrder);
	}
	
	private static void SetOrderCursorImage(int order) {
		Texture2D cursorImage = null;
		
		switch (order) {
			case C.ORDER_LOOK : {
				cursorImage = Factory.GetCursorImageOrderLookStatic();
				break;
			}
				
			case C.ORDER_TELEPORT : {
				cursorImage = Factory.GetCursorImageOrderTeleportStatic();
				break;
			}
				
			case C.ORDER_WALK : {
				cursorImage = Factory.GetCursorImageOrderWalkStatic();
				break;
			}
		}

		GUIManager.SetCursorImage(cursorImage);
	}

}
