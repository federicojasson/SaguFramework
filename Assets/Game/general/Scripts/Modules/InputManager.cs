using UnityEngine;

public static class InputManager {

	private static int cursorActionId;
	private static bool enabled;
	private static bool isCursorActionForced;
	private static float leftClickStartTime;
	private static int rotativeCursorActionsIndex;

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

	public static void ClearForcedCursorAction() {
		if (enabled) {
			isCursorActionForced = false;
			SetCursorAction(P.ROTATIVE_CURSOR_ACTIONS[rotativeCursorActionsIndex]);
		}
	}
	
	public static void Initialize() {
		enabled = true;
		isCursorActionForced = false;
		leftClickStartTime = -P.DELAY_DOUBLE_CLICK;
		rotativeCursorActionsIndex = 0;
		SetCursorAction(P.ROTATIVE_CURSOR_ACTIONS[rotativeCursorActionsIndex]);
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
				interactiveObject.OnCursorAction(cursorActionId);
			} else {
				// Double click
				leftClickStartTime = -P.DELAY_DOUBLE_CLICK;
				interactiveObject.OnCursorActionQuick(cursorActionId);
			}
	}

	public static void SetCursorLabel(string text) {
		if (enabled)
			Factory.ShowCursorLabel(text);
	}
	
	public static void SetForcedCursorAction(int cursorActionId) {
		if (enabled) {
			isCursorActionForced = true;
			SetCursorAction(cursorActionId);
		}
	}
	
	private static void CheckLeftClick() {
		if (Utility.WasLeftClickPressed())
			if (cursorActionId == P.CURSOR_ACTION_WALK) {
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
			if (! isCursorActionForced) {
				rotativeCursorActionsIndex = (rotativeCursorActionsIndex + 1) % P.ROTATIVE_CURSOR_ACTIONS.Length;
				SetCursorAction(P.ROTATIVE_CURSOR_ACTIONS[rotativeCursorActionsIndex]);
			}
	}

	private static void SetCursorAction(int cursorActionId) {
		InputManager.cursorActionId = cursorActionId;
		Utility.SetCursorTexture(Factory.GetCursorTexture(cursorActionId));
	}

	/*



	
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

	public static void SetCursorLabel(string text) {
		if (enabled)
			Factory.GetCursorLabel(text);
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
	}*/

}
