using UnityEngine;

public static partial class UtilityManager {
	
	/*public static Vector2 GameToWorldPosition(Vector2 gamePosition) {
		float x = (gamePosition.x - 0.5f) * GetGameScreenWidthPixels() / Parameters.PixelsPerUnit;
		float y = (gamePosition.y - 0.5f) * GetGameScreenHeightPixels() / Parameters.PixelsPerUnit;
		
		return new Vector2(x, y);
	}

	public static float GetCameraOrthographicSizeUnits() {
		return Screen.height / (2f * Parameters.PixelsPerUnit);
	}
	
	public static float GetGameScreenHeightPixels() {
		float screenAspectRatio = Screen.width / (float) Screen.height;
		float gameScreenAspectRatio = Parameters.GetGameScreenAspectRatio();
		
		if (gameScreenAspectRatio > screenAspectRatio)
			return Screen.width / gameScreenAspectRatio;
		else
			return Screen.height;
	}

	public static Rect GetGameScreenRectangle() {
		float gameScreenWidth = GetGameScreenWidthPixels();
		float gameScreenHeight = GetGameScreenHeightPixels();
		float gameScreenLeft = (Screen.width - gameScreenWidth) / 2;
		float gameScreenTop = (Screen.height - gameScreenHeight) / 2;

		return new Rect(gameScreenLeft, gameScreenTop, gameScreenWidth, gameScreenHeight);
	}
	
	public static float GetGameScreenWidthPixels() {
		float screenAspectRatio = Screen.width / (float) Screen.height;
		float gameScreenAspectRatio = Parameters.GetGameScreenAspectRatio();
		
		if (gameScreenAspectRatio > screenAspectRatio)
			return Screen.width;
		else
			return Screen.height * gameScreenAspectRatio;
	}

	public static float GetSpriteHeightUnits(Sprite sprite) {
		float spriteHeight = sprite.bounds.size.y;
		return GetGameScreenHeightPixels() / (Parameters.PixelsPerUnit * spriteHeight);
	}*/

}
