using UnityEngine;

public static partial class UtilityManager {

	public static float GetCameraOrthographicSizeUnits() {
		return Screen.height / (2f * Parameters.GetPixelsPerUnit());
	}

	public static float GetSpriteHeightUnits(Sprite sprite) {
		float spriteHeight = sprite.bounds.size.y;
		return GetGameScreenHeightPixels() / (Parameters.GetPixelsPerUnit() * spriteHeight);
	}
	
	private static float GetGameScreenHeightPixels() {
		float screenAspectRatio = Screen.width / (float) Screen.height;
		float gameScreenAspectRatio = Parameters.GetGameScreenAspectRatio();
		
		if (gameScreenAspectRatio > screenAspectRatio)
			return Screen.width / gameScreenAspectRatio;
		else
			return Screen.height;
	}

}
