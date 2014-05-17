using UnityEngine;

public static class GUIManager {

	public static bool DrawButton(string text, float x, float y, float width, float height) {
		// x and y are viewport coordinates and indicate where the center of the button should be

		// Transforms the position from viewport space to screen space and applies an offset to center it
		Vector2 screenPoint = Camera.current.ViewportToScreenPoint(new Vector2(x, y));
		x = screenPoint.x - width / 2;
		y = screenPoint.y - height / 2;

		Rect rectangle = new Rect(x, y, width, height);
		return GUI.Button(rectangle, text);
	}

}
