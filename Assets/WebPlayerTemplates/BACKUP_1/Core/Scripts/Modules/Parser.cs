using System.Globalization;

//
// Parser - Module class
//
// TODO: write class description
//
public static class Parser {
	
	public static float StringToFloat(string floatString) {
		return float.Parse(floatString, CultureInfo.InvariantCulture);
	}
	
}
