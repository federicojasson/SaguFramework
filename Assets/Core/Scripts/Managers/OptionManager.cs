using System.Collections.Generic;

public static partial class OptionManager {

	private static Dictionary<string, string> options;

	static OptionManager() {
		options = new Dictionary<string, string>();
	}

	public static bool GetBool(string id) {
		return UtilityManager.StringToBool(options[id]);
	}

	public static float GetFloat(string id) {
		return UtilityManager.StringToFloat(options[id]);
	}

	public static int GetInt(string id) {
		return UtilityManager.StringToInt(options[id]);
	}

	public static string GetString(string id) {
		return options[id];
	}

}
