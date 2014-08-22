using UnityEngine;

public static partial class UtilityManager {

	public static float GetCameraOrthographicSize() {
		return Screen.height / (2f * Parameters.GetPixelsPerUnit());
	}

	public static float GetGameScreenHeight() {
		float screenAspectRatio = Screen.width / (float) Screen.height;
		float gameScreenAspectRatio = Parameters.GetGameScreenAspectRatio();
		
		if (gameScreenAspectRatio > screenAspectRatio)
			return Screen.width / gameScreenAspectRatio;
		else
			return Screen.height;
	}
	
	public static float GetGameScreenWidth() {
		float screenAspectRatio = Screen.width / (float) Screen.height;
		float gameScreenAspectRatio = Parameters.GetGameScreenAspectRatio();
		
		if (gameScreenAspectRatio > screenAspectRatio)
			return Screen.width;
		else
			return Screen.height * gameScreenAspectRatio;
	}

}
