using System.Globalization;

public static class Parser {
	
	public static float StringToFloat(string floatString) {
		return float.Parse(floatString, CultureInfo.InvariantCulture);
	}
	
}
