public static class CursorManager {

	private static int action;
	private static bool enabled;

	public static void CheckInput() {
		if (enabled) {
			CheckLeftClick();
			CheckRightClick();
		}
	}

	public static void NotifyCursorEnter(InteractiveObject interactiveObject) {
		if (enabled) {
			// TODO

			// TODO: set cursor
			// TODO: should be call back for the interactiveObject
		}
	}

	public static void NotifyCursorExit(InteractiveObject interactiveObject) {
		if (enabled) {
			// TODO

			// TODO: clear cursor
			// TODO: should be call back for the interactiveObject
		}
	}

	public static void NotifyLeftClick(InteractiveObject interactiveObject) {
		if (enabled)
			interactiveObject.OnAction(action);
	}

}

/*public static class CursorManager {

	private static bool isInputCheckActivated;
	private static int cursorActionsIndex;
	private static int action;
	private static int previousAction;

	static CursorManager() {
		isInputCheckActivated = false;
		cursorActionsIndex = 0;
		action = P.CURSOR_ACTIONS[cursorActionsIndex];
		previousAction = CursorManager.action;
	}
	
	public static void ActivateInputCheck() {
		isInputCheckActivated = true;
	}

	public static void CheckInput() {
		if (isInputCheckActivated) {
			CheckLeftClick();
			CheckRightClick();
		}
	}

	public static void ClearLabel() {
		Factory.DisposeCursorLabel();
	}

	public static void DeactivateInputCheck() {
		isInputCheckActivated = false;
	}

	public static int GetAction() {
		return action;
	}
	
	public static int GetPreviousAction() {
		return previousAction;
	}
	
	public static void SetAction(int action) {
		previousAction = CursorManager.action;
		CursorManager.action = action;

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

	public static void SetLabel(string text) {
		Factory.GetCursorLabel(text);
	}

	private static void CheckLeftClick() {
		if (Utility.WasLeftClickPressed())
			if (action == P.ACTION_WALK)
				Game.GetPlayerCharacter().Walk(Utility.GetCursorWorldPosition());
	}
	
	private static void CheckRightClick() {
		if (Utility.WasRightClickPressed()) {
			cursorActionsIndex = (cursorActionsIndex + 1) % P.CURSOR_ACTIONS.Length;
			SetAction(P.CURSOR_ACTIONS[cursorActionsIndex]);
		}
	}

}*/
