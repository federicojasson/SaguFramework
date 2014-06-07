using UnityEngine;

public static class P {

	public const string FILE_PATH_CONFIGURATIONS = "Configurations";
	public static string FILE_PATH_LANGUAGE(string languageId) { return "Languages/" + languageId + "/Language"; }
	public static string FILE_PATH_LANGUAGE_AUDIO(string languageId, string audioPath) { return "Languages/" + languageId + "/" + audioPath; }
	public const string FILE_PATH_SAVEGAME = "Savegame";

	public const float DELAY_DOUBLE_CLICK = 0.3f;
	public const float DELAY_INITIALIZE_INPUT_MANAGER = 0.1f;

	public static Vector2 OFFSET_CURSOR_LABEL = new Vector2(0, -48);

	public const int ORDER_LOOK = 0;
	public const int ORDER_TELEPORT = 1;
	public const int ORDER_WAIT = 2;
	public const int ORDER_WALK = 3;

	public static int[] ROTATIVE_ORDERS = new int[] {
		ORDER_WALK,
		ORDER_LOOK
	};
	
	public const int ACTION_LOOK = 0;
	public const int ACTION_SAY = 1;
	public const int ACTION_WALK = 2;

	/*public const float DELTA_EQUAL = 0.001f;
	public const float DELTA_WALK = 0.5f;

	public static Vector2 OFFSET_SPEECH_TEXT = new Vector2(0, 0.25f);




	*/
	
}
