using System;
using System.Globalization;
using System.IO;
using UnityEngine;

public static class UtilityManager {

	public static string BoolToString(bool value) {
		return value.ToString();
	}

	public static Rect ComputeScreenRectangle() {
		// TODO: calculate this somehow
		return new Rect(0, 0, 1600, 900);
	}

	public static string FloatToString(float value) {
		return value.ToString(CultureInfo.InvariantCulture);
	}

	public static Timer InstantiateTimer() {
		return FrameworkAssets.InstantiateTimer();
	}

	public static string IntToString(int value) {
		return value.ToString(CultureInfo.InvariantCulture);
	}

	public static string ReadResourceTextFileContent(string resourcePath) {
		TextAsset textAsset = (TextAsset) Resources.Load(resourcePath, typeof(TextAsset));
		return textAsset.text;
	}
	
	public static string ReadTextFileContent(string path) {
		return File.ReadAllText(path);
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
