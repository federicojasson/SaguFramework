using UnityEngine;

namespace SaguFramework {
	
	public class Parameters : Worker {

		public const string DirectionLeft = "Left";
		public const string DirectionRight = "Right";

		public const string InitialOptionsFileResourcePath = "InitialOptions";
		public const string OptionsFileExtension = ".xml";
		public const string OptionsFileName = "Options";

		public const string InitialStateFileResourcePath = "InitialState";
		public const string StateFileExtension = ".xml";
		public const string StateFilesDirectoryPath = "States";

		public const string LanguageFileName = "Language";
		public const string LanguagesDirectoryResourcePath = "Languages";

		public const string OptionIdLanguage = "Language";
		public const string OptionIdEffectVolume = "EffectVolume";
		public const string OptionIdMasterVolume = "MasterVolume";
		public const string OptionIdSongVolume = "SongVolume";
		public const string OptionIdVoiceVolume = "VoiceVolume";

		public const float PixelsPerUnit = 1;

		public const string SceneMain = "Main";
		public const string SceneMainMenu = "MainMenu";
		public const string SceneRoom = "Room";
		public const string SceneSpecial = "Special";
		public const string SceneSplashScreen = "SplashScreen";

		public const string SkinStyleTooltip = "tooltip";

		public const string SortingLayerCharacter = "Character";
		public const string SortingLayerInventory = "Inventory";
		public const string SortingLayerInventoryItem = "InventoryItem";
		public const string SortingLayerItem = "Item";
		public const string SortingLayerMenu = "Menu";
		public const string SortingLayerRoomBackground = "RoomBackground";
		public const string SortingLayerRoomForeground = "RoomForeground";
		public const string SortingLayerSplashScreen = "SplashScreen";

		public const string XmlTagBoolean = "boolean";
		public const string XmlTagCharacter = "character";
		public const string XmlTagCharacterState = "character-state";
		public const string XmlTagCurrentRoomId = "current-room-id";
		public const string XmlTagDirection = "direction";
		public const string XmlTagFloat = "float";
		public const string XmlTagHint = "hint";
		public const string XmlTagId = "id";
		public const string XmlTagInteger = "integer";
		public const string XmlTagInventoryItem = "inventory-item";
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

		private static Parameters instance;

		public static Color GetCameraBackgroundColor() {
			return instance.GameParameters.Graphics.CameraBackgroundColor;
		}

		public static CharacterParameters GetCharacterParameters(string characterId) {
			return instance.GameParameters.Entities.Characters[characterId];
		}

		public static Texture2D GetDefaultFadeTexture() {
			return instance.GameParameters.Graphics.DefaultFadeTexture;
		}

		public static float GetDelayBetweenSongs() {
			return instance.GameParameters.Sounds.DelayBetweenSongs;
		}

		public static float GetGameAspectRatio() {
			return instance.GameParameters.Graphics.GameAspectRatio;
		}

		public static string GetGameDirectoryPath() {
			return instance.GameParameters.GameDirectoryPath;
		}

		public static InventoryItemParameters GetInventoryItemParameters(string inventoryItemId) {
			return instance.GameParameters.Entities.InventoryItems[inventoryItemId];
		}

		public static InventoryParameters GetInventoryParameters() {
			return instance.GameParameters.Entities.Inventory;
		}

		public static ItemParameters GetItemParameters(string itemId) {
			return instance.GameParameters.Entities.Items[itemId];
		}

		public static string GetLanguageFileResourcePath(string languageId) {
			return Utilities.GetFileResourcePath(LanguageFileName, LanguagesDirectoryResourcePath, languageId);
		}

		public static AudioClip GetMainEffect() {
			return instance.GameParameters.Sounds.MainEffect;
		}

		public static LoaderParameters GetMainLoaderParameters() {
			return instance.GameParameters.Loaders.Main;
		}

		public static LoaderParameters GetMainMenuLoaderParameters() {
			return instance.GameParameters.Loaders.MainMenu;
		}

		public static MenuParameters GetMainMenuParameters() {
			return instance.GameParameters.Entities.Menus.Main;
		}

		public static AudioClip GetMainMenuSong() {
			return instance.GameParameters.Sounds.MainMenuSong;
		}

		public static SplashScreenParameters GetMainSplashScreenParameters() {
			return instance.GameParameters.Entities.SplashScreens.Main;
		}

		public static MenuParameters GetMenuParameters(string menuId) {
			return instance.GameParameters.Entities.Menus.Others[menuId];
		}

		public static string GetOptionsFilePath() {
			string gameDirectoryPath = GetGameDirectoryPath();
			return Utilities.GetFilePath(OptionsFileName, OptionsFileExtension, gameDirectoryPath);
		}

		public static MenuParameters GetPauseMenuParameters() {
			return instance.GameParameters.Entities.Menus.Pause;
		}

		public static AudioClip[] GetPlaylist() {
			return instance.GameParameters.Sounds.Playlist;
		}

		public static LoaderParameters GetRoomLoaderParameters() {
			return instance.GameParameters.Loaders.Room;
		}

		public static RoomParameters GetRoomParameters(string roomId) {
			return instance.GameParameters.Entities.Rooms[roomId];
		}

		public static GUISkin GetSkin() {
			return instance.GameParameters.Graphics.Skin;
		}

		public static LoaderParameters GetSpecialLoaderParameters() {
			return instance.GameParameters.Loaders.Special;
		}

		public static LoaderParameters GetSplashScreenLoaderParameters() {
			return instance.GameParameters.Loaders.SplashScreen;
		}

		public static SplashScreenParameters[] GetSplashScreenParametersGroup(string groupId) {
			return instance.GameParameters.Entities.SplashScreens.Groups[groupId];
		}

		public static string GetStateFilePath(string stateId) {
			string gameDirectoryPath = GetGameDirectoryPath();
			return Utilities.GetFilePath(stateId, StateFileExtension, gameDirectoryPath, StateFilesDirectoryPath);
		}

		public static Texture2D GetWindowboxTexture() {
			return instance.GameParameters.Graphics.WindowboxTexture;
		}

		public static bool ShuffleSongs() {
			return instance.GameParameters.Sounds.ShuffleSongs;
		}

		public GameParameters GameParameters;

		public override void Awake() {
			base.Awake();
			instance = this;
		}

	}
	
}
