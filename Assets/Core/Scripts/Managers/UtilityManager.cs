using System.Globalization;
using UnityEngine;

public static class UtilityManager {

	public static string BooleanToString(bool value) {
		return value.ToString();
	}
	
	public static Timer CreateTimer() {
		return FrameworkAssets.CreateTimer();
	}

	public static string FloatToString(float value) {
		return value.ToString(CultureInfo.InvariantCulture);
	}
	
	public static Rect GetScreenRectangle() {
		// TODO: calculate this somehow
		return new Rect(0, 0, 1600, 900);
	}
	
	public static T Instantiate<T>(T prefab) where T : Object {
		return (T) Object.Instantiate(prefab);
	}

	public static T Instantiate<T>(T prefab, Vector2 position) where T : Object {
		return (T) Object.Instantiate(prefab, position, Quaternion.identity);
	}
	
	public static string IntegerToString(int value) {
		return value.ToString(CultureInfo.InvariantCulture);
	}

	public static T LoadResource<T>(string resourcePath) where T : Object {
		return (T) Resources.Load<T>(resourcePath);
	}

	public static bool StringToBoolean(string value) {
		return System.Boolean.Parse(value);
	}

	public static float StringToFloat(string value) {
		return float.Parse(value, CultureInfo.InvariantCulture);
	}
	
	public static int StringToInteger(string value) {
		return int.Parse(value, CultureInfo.InvariantCulture);
	}

}
