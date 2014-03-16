/*using UnityEngine;

public static class Utility {

	public static bool AreEqual(float float1, float float2, float delta) {
		return Mathf.Abs(float1 - float2) < delta;
	}
	
	public static Vector2 GetCursorScreenPosition() {
		return ToVector2(Input.mousePosition);
	}

	public static Vector2 GetCursorWorldPosition() {
		return ToVector2(Camera.main.ScreenToWorldPoint(Input.mousePosition));
	}

	public static Rect GetLabelRectangle(Vector2 position, string text) {
		Rect rectangle = GUILayoutUtility.GetRect(new GUIContent(text), GUI.skin.label);
		//rectangle.width += 2 * P.LABEL_HORIZONTAL_PADDING;
		//rectangle.height += 2 * P.LABEL_VERTICAL_PADDING;
		rectangle.x = position.x - rectangle.width / 2;
		rectangle.y = Screen.height - (position.y + rectangle.height / 2);

		return rectangle;
	}

	public static void SetCursorTexture(Texture2D texture) {
		Cursor.SetCursor(texture, new Vector2(texture.width / 2, texture.height / 2), CursorMode.ForceSoftware);
	}

	public static Vector2 ToVector2(Vector3 vector3) {
		return new Vector2(vector3.x, vector3.y);
	}

	public static bool WasLeftClickPressed() {
		return Input.GetMouseButtonDown(0);
	}

	public static bool WasRightClickPressed() {
		return Input.GetMouseButtonDown(1);
	}

}*/
