using UnityEngine;

//
// InputManager.ModePlay - Module class
//
// TODO: write description
//
public static partial class InputManager {

	private static int currentOrder;
	private static bool isCurrentOrderForced;
	private static int rotativeOrdersIndex;

	public static void ClearForcedOrder() {
		if (mode == C.INPUT_MANAGER_MODE_PLAY) {
			isCurrentOrderForced = false;
			
			// Sets the former rotative order
			SetOrder(C.ROTATIVE_ORDERS[rotativeOrdersIndex]);
		}
	}
	
	public static void SetForcedOrder(int order) {
		if (mode == C.INPUT_MANAGER_MODE_PLAY) {
			isCurrentOrderForced = true;
			
			// Sets the forced order
			SetOrder(order);
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
		if (Input.GetMouseButtonDown(1))
			// Right mouse button pressed
			if (! isCurrentOrderForced) {
				rotativeOrdersIndex = (rotativeOrdersIndex + 1) % C.ROTATIVE_ORDERS.Length;
				SetOrder(C.ROTATIVE_ORDERS[rotativeOrdersIndex]);
			}
	}

	private static void InitializeModePlay() {
		isCurrentOrderForced = false;
		rotativeOrdersIndex = 0;
		//SetOrder(C.ROTATIVE_ORDERS[rotativeOrdersIndex]); TODO
		currentOrder = C.ROTATIVE_ORDERS[rotativeOrdersIndex];
	}
	
	private static void SetCurrentOrderCursorImage() {
		Texture2D cursorImage = null;
		
		switch (currentOrder) {
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
	
	private static void SetModePlay() {
		SetCurrentOrderCursorImage();
	}
	
	private static void SetOrder(int order) {
		currentOrder = order;
		SetCurrentOrderCursorImage();
	}

}
