public static class InputManager {

	private static int actionId;
	private static int rotativeActionsIndex;
	private static bool enabled; // TODO: methods to disable and enable
	private static bool isActionForced;

	public static void CheckInput() {
		if (enabled) {
			CheckLeftClick();
			CheckRightClick();
		}
	}

	public static void ClearCursorLabel() {
		if (enabled)
			Factory.DisposeCursorLabel();
	}
	
	public static void ClearForcedAction() {
		if (enabled) {
			isActionForced = false;
			SetAction(P.CURSOR_ROTATIVE_ACTIONS[rotativeActionsIndex]);
		}
	}

	public static void Disable() {
		enabled = false;
		SetAction(P.CURSOR_ACTION_WAIT);
	}

	public static void Enable() {
		enabled = true;
		SetAction(P.CURSOR_ROTATIVE_ACTIONS[rotativeActionsIndex]);
	}

	public static void Initialize() {
		rotativeActionsIndex = 0;
		enabled = true;
		isActionForced = false;
		SetAction(P.CURSOR_ROTATIVE_ACTIONS[rotativeActionsIndex]);
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
			interactiveObject.OnAction(actionId);
	}

	public static void SetCursorLabel(string text) {
		if (enabled)
			Factory.GetCursorLabel(text);
	}

	public static void SetForcedAction(int action) {
		if (enabled) {
			SetAction(action);
			isActionForced = true;
		}
	}

	private static void CheckLeftClick() {
		if (Utility.WasLeftClickPressed())
			if (actionId == P.CURSOR_ACTION_WALK)
				Game.GetPlayerCharacter().Walk(Utility.GetCursorWorldPosition());
	}
	
	private static void CheckRightClick() {
		if (Utility.WasRightClickPressed())
			if (! isActionForced) {
				rotativeActionsIndex = (rotativeActionsIndex + 1) % P.CURSOR_ROTATIVE_ACTIONS.Length;
				SetAction(P.CURSOR_ROTATIVE_ACTIONS[rotativeActionsIndex]);
			}
	}
	
	private static void SetAction(int action) {
		InputManager.actionId = action;
		
		switch (action) {
			case P.CURSOR_ACTION_LOOK : {
				Utility.SetCursorTexture(Factory.GetCursorLookTexture());
				break;
			}
			
			case P.CURSOR_ACTION_TELEPORT : {
				Utility.SetCursorTexture(Factory.GetCursorTeleportTexture());
				break;
			}
			
			case P.CURSOR_ACTION_WAIT : {
				Utility.SetCursorTexture(Factory.GetCursorWaitTexture());
				break;
			}
			
			case P.CURSOR_ACTION_WALK : {
				Utility.SetCursorTexture(Factory.GetCursorWalkTexture());
				break;
			}
		}
	}

}
