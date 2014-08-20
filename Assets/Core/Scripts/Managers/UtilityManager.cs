using System;
using System.Globalization;
using UnityEngine;

public static class UtilityManager {

	public static string BoolToString(bool value) {
		return value.ToString();
	}

	public static string FloatToString(float value) {
		return value.ToString(CultureInfo.InvariantCulture);
	}
	
	public static Rect GetScreenRectangle() {
		// TODO: calculate this somehow
		return new Rect(0, 0, 1600, 900);
	}

	public static Timer InstantiateTimer() {
		return FrameworkAssets.InstantiateTimer();
	}

	public static string IntToString(int value) {
		return value.ToString(CultureInfo.InvariantCulture);
	}

	public static bool StringToBool(string value) {
		return Boolean.Parse(value);
	}

	public static float StringToFloat(string value) {
		return float.Parse(value, CultureInfo.InvariantCulture);
	}
	
	public static int StringToInt(string value) {
		return int.Parse(value, CultureInfo.InvariantCulture);
	}

}
