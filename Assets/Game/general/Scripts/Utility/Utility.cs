using System.Globalization;
using UnityEngine;

public static class Utility {
	
	public static void DisableComponent(Component component) {
		component.gameObject.SetActive(false);
	}
	
	public static void EnableComponent(Component component) {
		component.gameObject.SetActive(true);
	}
	
	public static Vector2 GetCursorScreenPosition() {
		return Input.mousePosition;
	}
	
	public static Rect GetLabelRectangle(Vector2 position, string text) {
		Rect rectangle = GUILayoutUtility.GetRect(new GUIContent(text), GUI.skin.label);
		rectangle.x = position.x - rectangle.width / 2;
		rectangle.y = Screen.height - (position.y + rectangle.height / 2);
		return rectangle;
	}

	public static Rect GetMenuButtonRectangle(Vector2 position, string text) {
		Rect rectangle = GUILayoutUtility.GetRect(new GUIContent(text), GUI.skin.button);
		rectangle.x = position.x - rectangle.width / 2;
		rectangle.y = position.y + rectangle.height / 2;
		return rectangle;
	}
	
	public static E[] PackParameters<E>(params E[] parameters) {
		E[] packedParameters = new E[parameters.Length];
		for (int i = 0; i < packedParameters.Length; ++i)
			packedParameters[i] = parameters[i];
		
		return packedParameters;
	}
	
	public static void SetCursorTexture(Texture2D texture) {
		Cursor.SetCursor(texture, new Vector2(texture.width / 2, texture.height / 2), CursorMode.ForceSoftware);
	}

	public static float ToFloat(string numberString) {
		return float.Parse(numberString, CultureInfo.InvariantCulture);
	}
	
	public static bool WasLeftClickPressed() {
		return Input.GetMouseButtonDown(0);
	}
	
	public static bool WasRightClickPressed() {
		return Input.GetMouseButtonDown(1);
	}

	/*public static bool AreEqual(float float1, float float2, float delta) {
		return Mathf.Abs(float1 - float2) < delta;
	}

	public static Vector2 FromScreenToWorldPosition(Vector2 position) {
		return Camera.main.ScreenToWorldPoint(position);
	}

	public static Vector2 FromWorldToViewportPosition(Vector2 position) {
		return Camera.main.WorldToViewportPoint(position);
	}

	public static Vector2 GetCursorWorldPosition() {
		return FromScreenToWorldPosition(GetCursorScreenPosition());
	}

	public static Vector3 ToVector3(Vector2 vector2, float z) {
		return new Vector3(vector2.x, vector2.y, z);
	}*/

}
