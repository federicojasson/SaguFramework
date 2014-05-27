//
// C - Module class
//
// This class defines framework constants. All constants and constant-dependent methods are defined here and only here.
//
// TODO: make sure that all constants are used somewhere
//
public static class C {

	public const int CHARACTER_ACTION_LOOK = 0;
	public const int CHARACTER_ACTION_SAY = 1;
	public const int CHARACTER_ACTION_WALK = 2;
	public const string CHARACTER_ATTRIBUTE_ID = "id";
	public const string CHARACTER_ROOM_TAG = "room";
	public const string CHARACTER_TAG = "character";
	public const string CHARACTER_X_TAG = "x";
	public const string CHARACTER_Y_TAG = "y";
	public const string CONFIGURATION_ATTRIBUTE_ID = "id";
	public const string CONFIGURATION_ID_LANGUAGE = "LANGUAGE";
	public const string CONFIGURATION_TAG = "configuration";
	public const string CURRENT_ROOM_TAG = "current-room";
	public const string FILE_PATH_CONFIGURATIONS = "Configurations";
	public static string FILE_PATH_LANGUAGE_TEXTS(string id) {
		return "Languages/" + id + "/Texts";
	}
	public const string FILE_PATH_NEW_GAME_STATE = "NewGameState";
	public const int INPUT_MANAGER_MODE_DISABLED = 0;
	public const int INPUT_MANAGER_MODE_PAUSE = 1;
	public const int INPUT_MANAGER_MODE_PLAY = 2;
	public const string INVENTORY_ITEM_ATTRIBUTE_ID = "id";
	public const string INVENTORY_ITEM_TAG = "inventory-item";
	public const string ITEM_ATTRIBUTE_ID = "id";
	public const string ITEM_ROOM_TAG = "room";
	public const string ITEM_TAG = "item";
	public const string ITEM_X_TAG = "x";
	public const string ITEM_Y_TAG = "y";
	public const int ORDER_LOOK = 0;
	public const int ORDER_TELEPORT = 1;
	public const int ORDER_WALK = 2;
	public const string PLAYER_CHARACTER_ID_TAG = "player-character-id";
	public static int[] ROTATIVE_ORDERS = new int[] {
		ORDER_WALK,
		ORDER_LOOK
	};
	public const string SORTING_LAYER_BACKGROUND = "Background";
	public const string SORTING_LAYER_SPLASH_SCREEN = "SplashScreen";
	public const string TEXT_ATTRIBUTE_ID = "id";
	public const string TEXT_TAG = "text";

}
