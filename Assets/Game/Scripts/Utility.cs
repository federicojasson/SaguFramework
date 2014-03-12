using UnityEngine;

public static class Utility {
	
	public static bool AreEqual(float f1, float f2) {
		return Mathf.Abs(f1 - f2) < P.DELTA;
	}

	public static Rect GetTextRectangle(Vector2 position, string text) {
		// TODO: calculate width according to text length
		float width = 128;
		float height = 64;
		return new Rect(position.x - width / 2, Screen.height - (position.y - height / 2), width, height);
	}

	public static Vector3 ScreenToWorldPosition(Vector3 position) {
		return Camera.main.ScreenToWorldPoint(position);
	}

	public static Vector2 ToVector2(Vector3 position) {
		return new Vector2(position.x, position.y);
	}

}
