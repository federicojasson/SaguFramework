public static class InputManager {

	private static int action;
	private static int cursorActionsIndex;
	private static bool enabled;
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
			SetAction(P.CURSOR_ACTIONS[cursorActionsIndex]);
		}
	}

	public static void Initialize() {
		cursorActionsIndex = 0;
		enabled = true;
		isActionForced = false;
		SetAction(P.CURSOR_ACTIONS[cursorActionsIndex]);
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
			interactiveObject.OnAction(action);
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
			if (action == P.ACTION_WALK)
				Game.GetPlayerCharacter().Walk(Utility.GetCursorWorldPosition());
	}
	
	private static void CheckRightClick() {
		if (Utility.WasRightClickPressed())
			if (! isActionForced) {
				cursorActionsIndex = (cursorActionsIndex + 1) % P.CURSOR_ACTIONS.Length;
				SetAction(P.CURSOR_ACTIONS[cursorActionsIndex]);
			}
	}
	
	private static void SetAction(int action) {
		InputManager.action = action;
		
		switch (action) {
			case P.ACTION_LOOK : {
				Utility.SetCursorTexture(Factory.GetCursorLookTexture());
				break;
			}
				
			case P.ACTION_TELEPORT : {
				Utility.SetCursorTexture(Factory.GetCursorTeleportTexture());
				break;
			}
				
			case P.ACTION_WALK : {
				Utility.SetCursorTexture(Factory.GetCursorWalkTexture());
				break;
			}
		}
	}

}
