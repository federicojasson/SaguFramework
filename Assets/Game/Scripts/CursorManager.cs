using UnityEngine;

public static class CursorManager {

	private static FollowerLabel label;

	public static void ClearLabel() {
		Factory.DestroyCursorLabel(label);
	}

	public static Vector2 GetCursorScreenPosition() {
		return Utility.ToVector2(Input.mousePosition);
	}

	public static Vector2 GetCursorWorldPosition() {
		return Utility.ToVector2(Utility.ScreenToWorldPosition(Input.mousePosition));
	}
	
	public static void SetIcon(int action) {
		switch (action) {
			case P.ACTION_LOOK : {
				SetIcon(Factory.GetLookCursorIcon());
				break;
			}

			case P.ACTION_WALK : {
				SetIcon(Factory.GetWalkCursorIcon());
				break;
			}

			case P.SPECIAL_ACTION_TELEPORT : {
				SetIcon(Factory.GetTeleportCursorIcon());
				break;
			}
		}
	}

	public static void SetLabel(string text) {
		label = Factory.CreateCursorLabel(P.CURSOR_LABEL_OFFSET, text);
	}
	
	private static void SetIcon(Texture2D icon) {
		Cursor.SetCursor(icon, new Vector2(icon.width / 2, icon.height / 2), CursorMode.ForceSoftware);
	}
	
}
