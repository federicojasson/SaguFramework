using System.Globalization;
using UnityEngine;

public static class UtilityManager {

	public static string BoolToString(bool value) {
		return value.ToString();
	}
	
	public static Timer CreateTimer() {
		return FrameworkAssets.CreateTimer();
	}

	public static void Destroy(GameObject gameObject) {
		Object.Destroy(gameObject);
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
	
	public static string IntToString(int value) {
		return value.ToString(CultureInfo.InvariantCulture);
	}

	public static bool StringToBool(string value) {
		return System.Boolean.Parse(value);
	}

	public static float StringToFloat(string value) {
		return float.Parse(value, CultureInfo.InvariantCulture);
	}
	
	public static int StringToInt(string value) {
		return int.Parse(value, CultureInfo.InvariantCulture);
	}

}
