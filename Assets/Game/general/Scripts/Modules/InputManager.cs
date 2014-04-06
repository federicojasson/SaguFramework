using UnityEngine;

public static class InputManager {

	private static int actionId;
	private static bool enabled;
	private static bool isActionForced;
	private static int rotativeActionsIndex;

	public static void CheckInput() {
		if (enabled) {
			CheckLeftClick();
			CheckRightClick();
		}
	}
	
	public static void Initialize() {
		enabled = true;
		isActionForced = false;
		rotativeActionsIndex = 0;
		SetAction(P.CURSOR_ROTATIVE_ACTIONS[rotativeActionsIndex]);
	}
	
	private static void CheckLeftClick() {
		if (Utility.WasLeftClickPressed())
			if (actionId == P.CURSOR_ACTION_WALK) {
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
			if (! isActionForced) {
				rotativeActionsIndex = (rotativeActionsIndex + 1) % P.CURSOR_ROTATIVE_ACTIONS.Length;
				SetAction(P.CURSOR_ROTATIVE_ACTIONS[rotativeActionsIndex]);
			}
	}

	private static void SetAction(int actionId) {
		InputManager.actionId = actionId;
		Utility.SetCursorTexture(Factory.GetCursorTexture(actionId));
	}

	/*


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
			isActionForced = true;
			SetAction(action);
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
	}*/

}
