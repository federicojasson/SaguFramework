public static class P {

	public const int ACTION_LOOK = 0;
	public const int ACTION_TELEPORT = 1;
	public const int ACTION_WALK = 2;

	public static string CONFIGURATION_FILE_PATH = "Configuration";
	public static string LANGUAGE_FILE_PATH(string languageId) {
		return "Languages/" + languageId + "/Language";
	}

}

/*using UnityEngine;

public static class P {

	public const float DELTA_EQUAL = 0.001f;
	public const float DELTA_WALK = 0.5f;
	
	public const float DELAY_DOUBLE_CLICK = 0.3f;
	public const float DELAY_INITIALIZE_CURSOR_MANAGER = 0.1f;

	public const int ACTION_LOOK = 0;
	public const int ACTION_TELEPORT = 1;
	public const int ACTION_WALK = 2;

	public static int[] CURSOR_ACTIONS = new int[] {
		ACTION_WALK,
		ACTION_LOOK
	};

	public static Vector2 OFFSET_CURSOR_LABEL = new Vector2(0, -48);
	public static Vector3 OFFSET_SPEECH_TEXT = new Vector3(0, 0.25f, 0); // TODO

}*/
