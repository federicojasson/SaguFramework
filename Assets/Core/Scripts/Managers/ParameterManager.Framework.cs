using UnityEngine;

namespace SaguFramework {
	
	public static partial class ParameterManager {
		
		// TODO: usar esta clase para obtener parametros del framework

		public const string InitialOptionsFileResourcePath = "InitialOptions";
		public const string InitialStateFileResourcePath = "InitialState";
		
		public const string LanguageFileName = "Language";
		public const string LanguagesDirectoryResourcePath = "Languages";

		public const float PixelsPerUnit = 1;

		public const string OptionIdLanguage = "Language";
		public const string OptionIdMasterVolume = "MasterVolume";
		public const string OptionIdSongVolume = "SongVolume";
		public const string OptionIdVoiceVolume = "VoiceVolume";

		public const string SceneMain = "Main";
		public const string SceneMainMenu = "MainMenu";
		public const string SceneRoom = "Room";
		public const string SceneSpecial = "Special";
		public const string SceneSplashScreen = "SplashScreen";

		public const string SortingLayerCharacterImage = "CharacterImage";
		public const string SortingLayerInventoryBackgroundImage = "InventoryBackgroundImage";
		public const string SortingLayerInventoryItemImage = "InventoryItemImage";
		public const string SortingLayerItemImage = "ItemImage";
		public const string SortingLayerMenuBackgroundImage = "MenuBackgroundImage";
		public const string SortingLayerRoomBackgroundImage = "RoomBackgroundImage";
		public const string SortingLayerRoomForegroundImage = "RoomForegroundImage";
		public const string SortingLayerSplashScreenImage = "SplashScreenImage";

		public const string OptionsFileExtension = ".xml";
		public const string optionsFileName = "Options";
		
		public const string StateFileExtension = ".xml";
		public const string StateFilesDirectoryPath = "States";

		public const string XmlTagBoolean = "boolean";
		public const string XmlTagCharacter = "character";
		public const string XmlTagCurrentRoomId = "current-room-id";
		public const string XmlTagFloat = "float";
		public const string XmlTagId = "id";
		public const string XmlTagInteger = "integer";
		public const string XmlTagInventoryItem = "inventory-item";
		public const string XmlTagInventoryPage = "inventory-page";
		public const string XmlTagItem = "item";
		public const string XmlTagLanguage = "language";
		public const string XmlTagLocation = "location";
		public const string XmlTagOptions = "options";
		public const string XmlTagPlayerCharacter = "player-character";
		public const string XmlTagPositionInGame = "position-in-game";
		public const string XmlTagResourcePath = "resource-path";
		public const string XmlTagRoomId = "room-id";
		public const string XmlTagState = "state";
		public const string XmlTagString = "string";
		public const string XmlTagText = "text";
		public const string XmlTagValue = "value";
		public const string XmlTagVoice = "voice";
		public const string XmlTagX = "x";
		public const string XmlTagY = "y";
		
		public static Texture2D GetFadingTexture() {
			return Framework.GetInstance().FrameworkParameters.FadingTexture;
		}

		public static string GetLanguageFileResourcePath(string languageId) {
			// Gets the file's resource path and returns it
			return UtilityManager.GetFileResourcePath(LanguageFileName, LanguagesDirectoryResourcePath, languageId);
		}

		public static string GetOptionsFilePath() {
			// Gets the game's directory path
			string gameDirectoryPath = GetGameDirectoryPath();
			
			// Gets the file's path and returns it
			return UtilityManager.GetFilePath(optionsFileName, OptionsFileExtension, gameDirectoryPath);
		}
		
		public static string GetStateFilePath(string stateId) {
			// Gets the game's directory path
			string gameDirectoryPath = GetGameDirectoryPath();

			// Gets the file's path and returns it
			return UtilityManager.GetFilePath(stateId, StateFileExtension, gameDirectoryPath, StateFilesDirectoryPath);
		}

		public static string GetStateFilesDirectoryPath() {
			// Gets the game's directory path
			string gameDirectoryPath = GetGameDirectoryPath();

			// Gets the directory's path and returns it
			return UtilityManager.GetDirectoryPath(gameDirectoryPath, StateFilesDirectoryPath);
		}
		
		public static Texture2D GetWindowboxingTexture() {
			return Framework.GetInstance().FrameworkParameters.WindowboxingTexture;
		}
		
	}
	
}
