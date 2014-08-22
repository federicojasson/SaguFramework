using System.Globalization;

public static partial class UtilityManager {

	public static string BooleanToString(bool value) {
		return value.ToString();
	}

	public static string FloatToString(float value) {
		return value.ToString(CultureInfo.InvariantCulture);
	}

	public static string IntegerToString(int value) {
		return value.ToString(CultureInfo.InvariantCulture);
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
