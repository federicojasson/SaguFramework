using UnityEngine;

public static class InputManager {

	private static int previousAction;
	private static int currentAction;

	static InputManager() {
		previousAction = P.ACTION_WALK;
		currentAction = P.ACTION_WALK;
	}

	public static void CheckInput() {
		CheckLeftClick();
		CheckRightClick();
	}
	
	public static void SetAction(int action) {
		previousAction = currentAction;
		currentAction = action;
		CursorManager.SetIcon(action);
	}
	
	public static void SetPreviousAction() {
		SetAction(previousAction);
	}

	private static void CheckLeftClick() {
		if (Input.GetMouseButtonUp(0))
			switch (currentAction) {
				// TODO
				case P.ACTION_LOOK : break;
				case P.ACTION_WALK : {
					Game.instance.playerCharacter.Walk(CursorManager.GetCursorWorldPosition().x);
					break;
				}
			}
	}

	private static void CheckRightClick() {
		if (Input.GetMouseButtonUp(1))
			SetNextAction();
	}
	
	private static bool IsSpecialActionSet() {
		return currentAction >= P.ACTIONS;
	}

	private static void SetNextAction() {
		if (! IsSpecialActionSet())
			SetAction((currentAction + 1) % P.ACTIONS);
	}

}
