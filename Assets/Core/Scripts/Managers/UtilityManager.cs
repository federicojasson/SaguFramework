using UnityEngine;

public static class UtilityManager {
	
	public static Rect ComputeScreenRectangle() {
		// TODO: calculate this somehow
		return new Rect(0, 0, 1600, 900);
	}

	public static Timer CreateTimer() {
		return FrameworkAssets.CreateTimer();
	}

}
