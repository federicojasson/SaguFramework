using UnityEngine;

public static class InputManager {

	private static int currentOrderId;
	private static bool enabled;
	private static bool isCurrentOrderForced;
	private static float leftClickStartTime;
	private static int rotativeOrdersIndex;

	public static void CheckInput() {
		if (enabled) {
			CheckLeftClick();
			CheckRightClick();
		}
	}

	public static void ClearCursorLabel() {
		if (enabled)
			Factory.HideCursorLabel();
	}

	public static void ClearForcedOrder() {
		if (enabled) {
			isCurrentOrderForced = false;
			SetOrder(P.ROTATIVE_ORDERS[rotativeOrdersIndex]);
		}
	}
	
	public static void Initialize() {
		enabled = true;
		isCurrentOrderForced = false;
		leftClickStartTime = -P.DELAY_DOUBLE_CLICK;
		rotativeOrdersIndex = 0;
		SetOrder(P.ROTATIVE_ORDERS[rotativeOrdersIndex]);
	}

	public static void NotifyCursorEnter(InteractiveObject interactiveObject) {
		if (enabled)
			interactiveObject.OnFocus();
	}
	
	public static void NotifyCursorExit(InteractiveObject interactiveObject) {
		if (enabled)
			interactiveObject.OnDefocus();
	}
	
	public static void NotifyLeftClick(InteractiveObject interactiveObject) {
		if (enabled)
			if ((Time.time - leftClickStartTime) > P.DELAY_DOUBLE_CLICK) {
				// Single click
				leftClickStartTime = Time.time;
				interactiveObject.OnOrder(currentOrderId);
			} else {
				// Double click
				leftClickStartTime = -P.DELAY_DOUBLE_CLICK;
				interactiveObject.OnQuickOrder(currentOrderId);
			}
	}

	public static void SetCursorLabel(string text) {
		if (enabled)
			Factory.ShowCursorLabel(text);
	}
	
	public static void SetForcedOrder(int orderId) {
		if (enabled) {
			isCurrentOrderForced = true;
			SetOrder(orderId);
		}
	}
	
	private static void CheckLeftClick() {
		if (Utility.WasLeftClickPressed())
			if (currentOrderId == P.ORDER_WALK) {
				Debug.Log("left click");
				// TODO
				/*Character playerCharacter = Game.GetPlayerCharacter();
				Vector2 position = Utility.GetCursorWorldPosition();
				
				playerCharacter.CancelScheduledActions();
				playerCharacter.Look(position);
				playerCharacter.Walk(position);*/
			}
	}
	
	private static void CheckRightClick() {
		if (Utility.WasRightClickPressed())
			if (! isCurrentOrderForced) {
				rotativeOrdersIndex = (rotativeOrdersIndex + 1) % P.ROTATIVE_ORDERS.Length;
				SetOrder(P.ROTATIVE_ORDERS[rotativeOrdersIndex]);
			}
	}

	private static void SetOrder(int orderId) {
		currentOrderId = orderId;
		Utility.SetCursorTexture(Factory.GetCursorTexture(orderId));
	}

	/*
	// TODO
	public static void Disable() {
		enabled = false;
		SetAction(P.CURSOR_ACTION_WAIT);
	}

	public static void Enable() {
		enabled = true;
		SetAction(P.CURSOR_ROTATIVE_ACTIONS[rotativeActionsIndex]);
	}*/

}
