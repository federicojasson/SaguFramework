using UnityEngine;

public static class CoordinatesManager {

	public static Vector2 GameToScreenDimensions(Vector2 gameDimensions) {
		Vector2 screenPointStart = GameToScreenPoint(new Vector2(0, 0));
		Vector2 screenPointEnd = GameToScreenPoint(gameDimensions);
		
		return screenPointEnd - screenPointStart;
	}

	public static Vector2 GameToScreenPoint(Vector2 gamePoint) {
		float gameScreenHeight = Screen.width / C.GAME_SCREEN_ASPECT_RATIO;

		Vector2 screenPoint = new Vector2();
		screenPoint.x = gamePoint.x * Screen.width;
		screenPoint.y = gamePoint.y * gameScreenHeight + (Screen.height - gameScreenHeight) / 2;

		return screenPoint;
	}

	public static Vector2 GameToViewportDimensions(Vector2 gameDimensions) {
		Vector2 viewportPointStart = GameToViewportPoint(new Vector2(0, 0));
		Vector2 viewportPointEnd = GameToViewportPoint(gameDimensions);
		
		return viewportPointEnd - viewportPointStart;
	}
	
	public static Vector2 GameToViewportPoint(Vector2 gamePoint) {
		Vector2 screenPoint = GameToScreenPoint(gamePoint);
		return Camera.main.ScreenToViewportPoint(screenPoint);
	}

	public static Vector2 GameToWorldDimensions(Vector2 gameDimensions) {
		Vector2 worldPointStart = GameToWorldPoint(new Vector2(0, 0));
		Vector2 worldPointEnd = GameToWorldPoint(gameDimensions);

		return worldPointEnd - worldPointStart;
	}

	public static Vector2 GameToWorldPoint(Vector2 gamePoint) {
		Vector2 screenPoint = GameToScreenPoint(gamePoint);
		return Camera.main.ScreenToWorldPoint(screenPoint);
	}

	public static Vector2 ScreenToGameDimensions(Vector2 screenDimensions) {
		Vector2 gamePointStart = ScreenToGamePoint(new Vector2(0, 0));
		Vector2 gamePointEnd = ScreenToGamePoint(screenDimensions);
		
		return gamePointEnd - gamePointStart;
	}

	public static Vector2 ScreenToGamePoint(Vector2 screenPoint) {
		float gameScreenHeight = Screen.width / C.GAME_SCREEN_ASPECT_RATIO;

		Vector2 gamePoint = new Vector2();
		gamePoint.x = screenPoint.x / Screen.width;
		gamePoint.y = (screenPoint.y - (Screen.height - gameScreenHeight) / 2) / gameScreenHeight;

		return gamePoint;
	}

	public static Vector2 ViewportToGameDimensions(Vector2 viewportDimensions) {
		Vector2 gamePointStart = ViewportToGamePoint(new Vector2(0, 0));
		Vector2 gamePointEnd = ViewportToGamePoint(viewportDimensions);
		
		return gamePointEnd - gamePointStart;
	}

	public static Vector2 ViewportToGamePoint(Vector2 viewportPoint) {
		Vector2 screenPoint = Camera.main.ViewportToScreenPoint(viewportPoint);
		return ScreenToGamePoint(screenPoint);
	}

	public static Vector2 WorldToGameDimensions(Vector2 worldDimensions) {
		Vector2 gamePointStart = WorldToGamePoint(new Vector2(0, 0));
		Vector2 gamePointEnd = WorldToGamePoint(worldDimensions);
		
		return gamePointEnd - gamePointStart;
	}
	
	public static Vector2 WorldToGamePoint(Vector2 worldPoint) {
		Vector2 screenPoint = Camera.main.WorldToScreenPoint(worldPoint);
		return ScreenToGamePoint(screenPoint);
	}

}
