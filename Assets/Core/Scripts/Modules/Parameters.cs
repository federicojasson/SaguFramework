using UnityEngine;

namespace SaguFramework {
	
	public static class Parameters {

		public const float PixelsPerUnit = 1;

		public const string DirectionLeft = "Left";
		public const string DirectionRight = "Right";

		public const string LanguageFileName = "Language";
		public const string LanguagesDirectoryResourcePath = "Languages";
		
		public const string InitialOptionsFileResourcePath = "InitialOptions";
		public const string OptionsFileExtension = ".xml";
		public const string OptionsFileName = "Options";

		public const string OptionIdLanguage = "Language";
		public const string OptionIdEffectVolume = "EffectVolume";
		public const string OptionIdMasterVolume = "MasterVolume";
		public const string OptionIdSongVolume = "SongVolume";
		public const string OptionIdVoiceVolume = "VoiceVolume";

		public const string InitialStateFileResourcePath = "InitialState";
		public const string StateFileExtension = ".xml";
		public const string StateFilesDirectoryPath = "States";

		public const string SceneMain = "Main";
		public const string SceneMainMenu = "MainMenu";
		public const string SceneRoom = "Room";
		public const string SceneSpecial = "Special";
		public const string SceneSplashScreen = "SplashScreen";

		public const string SortingLayerCharacter = "Character";
		public const string SortingLayerInventory = "Inventory";
		public const string SortingLayerInventoryItem = "InventoryItem";
		public const string SortingLayerItem = "Item";
		public const string SortingLayerMenu = "Menu";
		public const string SortingLayerRoomBackground = "RoomBackground";
		public const string SortingLayerRoomForeground = "RoomForeground";
		public const string SortingLayerSplashScreen = "SplashScreen";

		// TODO: descomentar por partes
		public const string XmlTagBoolean = "boolean";
		public const string XmlTagCharacter = "character";
		public const string XmlTagCharacterState = "character-state";
		public const string XmlTagCurrentRoomId = "current-room-id";
		public const string XmlTagDirection = "direction";
		public const string XmlTagFloat = "float";
		public const string XmlTagHint = "hint";
		public const string XmlTagId = "id";
		public const string XmlTagInteger = "integer";
		/*public const string XmlTagInventoryItem = "inventory-item";
		public const string XmlTagInventoryPage = "inventory-page";*/
		public const string XmlTagItem = "item";
		public const string XmlTagItemState = "item-state";
		public const string XmlTagLanguage = "language";
		public const string XmlTagLocation = "location";
		public const string XmlTagOptions = "options";
		public const string XmlTagPlayerCharacterId = "player-character-id";
		public const string XmlTagPosition = "position";
		public const string XmlTagResourcePath = "resource-path";
		public const string XmlTagRoomId = "room-id";
		public const string XmlTagState = "state";
		public const string XmlTagString = "string";
		public const string XmlTagText = "text";
		public const string XmlTagValue = "value";
		public const string XmlTagVoice = "voice";
		public const string XmlTagX = "x";
		public const string XmlTagY = "y";

		public static Color GetCameraBackgroundColor() {
			return FrameworkDelegate.GetInstance().FrameworkParameters.CameraBackgroundColor;
		}

		public static Character GetCharacter() {
			return FrameworkDelegate.GetInstance().FrameworkParameters.Character;
		}

		public static CharacterParameters GetCharacterParameters(string id) {
			return GameDelegate.GetInstance().GameParameters.Characters[id];
		}

		public static float GetGameAspectRatio() {
			return GameDelegate.GetInstance().GameParameters.GameAspectRatio;
		}

		public static string GetGameDirectoryPath() {
			return GameDelegate.GetInstance().GameParameters.GameDirectoryPath;
		}
		
		public static Image GetImage() {
			return FrameworkDelegate.GetInstance().FrameworkParameters.Image;
		}

		public static Interactive GetInteractive() {
			return FrameworkDelegate.GetInstance().FrameworkParameters.Interactive;
		}

		public static Item GetItem() {
			return FrameworkDelegate.GetInstance().FrameworkParameters.Item;
		}

		public static ItemParameters GetItemParameters(string id) {
			return GameDelegate.GetInstance().GameParameters.Items[id];
		}

		public static string GetLanguageFileResourcePath(string id) {
			return Utilities.GetFileResourcePath(LanguageFileName, LanguagesDirectoryResourcePath, id);
		}
		
		public static Menu GetMenu() {
			return FrameworkDelegate.GetInstance().FrameworkParameters.Menu;
		}

		public static MenuParameters GetMainMenuParameters() {
			return GameDelegate.GetInstance().GameParameters.Menus.Main;
		}

		public static SplashScreenParameters GetMainSplashScreenParameters() {
			return GameDelegate.GetInstance().GameParameters.SplashScreens.Main;
		}

		public static MenuParameters GetMenuParameters(string id) {
			return GameDelegate.GetInstance().GameParameters.Menus.Menus[id];
		}

		public static string GetOptionsFilePath() {
			string gameDirectoryPath = GetGameDirectoryPath();
			return Utilities.GetFilePath(OptionsFileName, OptionsFileExtension, gameDirectoryPath);
		}

		public static Room GetRoom() {
			return FrameworkDelegate.GetInstance().FrameworkParameters.Room;
		}

		public static RoomParameters GetRoomParameters(string id) {
			return GameDelegate.GetInstance().GameParameters.Rooms[id];
		}

		public static SplashScreen GetSplashScreen() {
			return FrameworkDelegate.GetInstance().FrameworkParameters.SplashScreen;
		}

		public static SplashScreenParameters[] GetSplashScreenParametersGroup(string id) {
			return GameDelegate.GetInstance().GameParameters.SplashScreens.Groups[id];
		}
		
		public static string GetStateFilePath(string id) {
			string gameDirectoryPath = GetGameDirectoryPath();
			return Utilities.GetFilePath(id, StateFileExtension, gameDirectoryPath, StateFilesDirectoryPath);
		}

		public static Trigger GetTrigger() {
			return FrameworkDelegate.GetInstance().FrameworkParameters.Trigger;
		}

		public static Texture2D GetWindowboxingTexture() {
			return FrameworkDelegate.GetInstance().FrameworkParameters.WindowboxingTexture;
		}

	}
	
}
