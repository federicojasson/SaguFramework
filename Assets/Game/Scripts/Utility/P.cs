using UnityEngine;

public static class P {

	public const float DELTA_EQUAL = 0.001f;
	public const float DELTA_WALK = 0.5f;

	public const float DELAY_INITIALIZE_INPUT_MANAGER = 0.1f;

	public static Vector2 OFFSET_CURSOR_LABEL = new Vector2(0, -48);
	public static Vector2 OFFSET_SPEECH_TEXT = new Vector2(0, 0.25f);

	public const int CURSOR_ACTION_LOOK = 0;
	public const int CURSOR_ACTION_TELEPORT = 1;
	public const int CURSOR_ACTION_WAIT = 2;
	public const int CURSOR_ACTION_WALK = 3;

	public static int[] CURSOR_ROTATIVE_ACTIONS = new int[] {
		CURSOR_ACTION_WALK,
		CURSOR_ACTION_LOOK
	};

	public const int CHARACTER_ACTION_LOOK = 0;
	public const int CHARACTER_ACTION_SAY = 1;
	public const int CHARACTER_ACTION_WALK = 2;

	public static string CONFIGURATIONS_FILE_PATH = "Configurations";

	public static string LANGUAGE_AUDIO_PATH(string languageId, string audioPath) {
		return "Languages/" + languageId + "/" + audioPath;
	}

	public static string LANGUAGE_FILE_PATH(string languageId) {
		return "Languages/" + languageId + "/Language";
	}
	
}

/*using UnityEngine;
// TODO
public static class P {


	
	public const float DELAY_DOUBLE_CLICK = 0.3f;

}*/
