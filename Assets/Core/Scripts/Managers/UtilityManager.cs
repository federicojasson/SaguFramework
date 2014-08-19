using System;
using System.Globalization;
using UnityEngine;

public static class UtilityManager {
	
	public static Rect ComputeScreenRectangle() {
		// TODO: calculate this somehow
		return new Rect(0, 0, 1600, 900);
	}

	public static Timer CreateTimer() {
		return FrameworkAssets.CreateTimer();
	}

	public static bool StringToBool(string value) {
		// TODO: if it fails?
		return Boolean.Parse(value);
	}

	public static float StringToFloat(string value) {
		// TODO: if it fails?
		return float.Parse(value, CultureInfo.InvariantCulture);
	}
	
	public static int StringToInt(string value) {
		// TODO: if it fails?
		return int.Parse(value, CultureInfo.InvariantCulture);
	}

}
