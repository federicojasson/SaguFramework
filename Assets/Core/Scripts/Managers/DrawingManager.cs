using UnityEngine;

public static class DrawingManager {

	public static bool DrawButton(string text, Rect rectangle) {
		// TODO: a change of position's coordinates might be necessary
		Rect centeredRectangle = ComputeCenteredRectangle(rectangle);

		return GUI.Button(centeredRectangle, text);
	}

	private static Rect ComputeCenteredRectangle(Rect rectangle) {
		// Applies an offset to the coordinates to center the rectangle
		float x = rectangle.x - rectangle.width / 2;
		float y = rectangle.y - rectangle.height / 2;

		return new Rect(x, y, rectangle.width, rectangle.height);
	}

}
