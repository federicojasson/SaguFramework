using UnityEngine;

public static class InputManager {

	public static void CheckInput() {
		CheckLeftClick();
		CheckRightClick();
	}

	private static void CheckLeftClick() {
		if (Input.GetMouseButtonUp(0))
			switch (Game.instance.GetCurrentAction()) {
				// TODO
				case P.ACTION_LOOK : break;
				case P.ACTION_WALK : {
					Game.instance.playerCharacter.Walk(GetCursorX());
					break;
				}
			}
	}

	private static void CheckRightClick() {
		if (Input.GetMouseButtonUp(1))
			Game.instance.SetNextAction();
	}
	
	private static float GetCursorX() {
		return Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
	}

}
