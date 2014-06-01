using UnityEngine;

public static class CoordinatesManager {

	private const float GAME_ASPECT_RATIO = 16f / 9f; // TODO: define it somewhere else

	public static bool AreEqualX(float x1, float x2, float delta) {
		return Mathf.Abs(x1 - x2) < delta;
	}

	public static Vector2 GetCursorPosition() {
		return Input.mousePosition;
	}







	public static Vector2 GameToScreenPoint(Vector2 gamePoint) {
		float gameScreenHeight = Screen.width / GAME_ASPECT_RATIO;

		Vector2 screenPoint = new Vector2();
		screenPoint.x = gamePoint.x * Screen.width;
		screenPoint.y = gamePoint.y * gameScreenHeight + (Screen.height - gameScreenHeight) / 2);

		return screenPoint;
	}
	
	public static Vector2 GameToScreenPoint(Vector2 gamePoint) {
		Vector2 screenPoint = GameToScreenPoint(gamePoint);
		return Camera.main.ScreenToViewportPoint(screenPoint);
	}
	
	public static Vector2 GameToWorldPoint(Vector2 gamePoint) {
		Vector2 screenPoint = GameToScreenPoint(gamePoint);
		return Camera.main.ScreenToWorldPoint(screenPoint);
	}

	public static Vector2 ScreenToGamePoint(Vector2 screenPoint) {
		float gameScreenHeight = Screen.width / GAME_ASPECT_RATIO;

		Vector2 gamePoint = new Vector2();
		gamePoint.x = screenPoint.x / Screen.width;
		gamePoint.y = (screenPoint.y - (Screen.height - gameScreenHeight) / 2) / gameScreenHeight;

		return gamePoint;
	}

	public static Vector2 ViewportToGamePoint(Vector2 viewportPoint) {
		Vector2 screenPoint = Camera.main.ViewportToScreenPoint(viewportPoint);
		return ScreenToGamePoint(screenPoint);
	}

	public static Vector2 WorldToGamePoint(Vector2 worldPoint) {
		Vector2 screenPoint = Camera.main.WorldToScreenPoint(worldPoint);
		return ScreenToGamePoint(screenPoint);
	}

}
