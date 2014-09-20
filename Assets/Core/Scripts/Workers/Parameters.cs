using UnityEngine;

namespace SaguFramework {
	
	public sealed class Parameters : Worker {

		public const string AxisNameScrollWheel = "Mouse ScrollWheel";

		public const string CharacterAnimatorControllerIsDirectionLeft = "IsDirectionLeft";
		public const string CharacterAnimatorControllerIsSaying = "IsSaying";
		public const string CharacterAnimatorControllerIsWalking = "IsWalking";
		public const string CharacterAnimatorControllerPickUp = "PickUp";
		
		public const string DefaultOptionsFileResourcePath = "DefaultOptions";

		public const float DeltaDistance = 0.00125f;
		
		public const float DepthCamera = -1000;
		public const float DepthCharacter = -400;
		public const float DepthInventory = -500;
		public const float DepthInventoryItem = -600;
		public const float DepthInventoryTrigger = -700;
		public const float DepthItem = -300;
		public const float DepthMenu = -800;
		public const float DepthRoom = -100;
		public const float DepthRoomTrigger = -200;
		public const float DepthSplashScreen = -900;

		public const string InitialStateFileResourcePath = "InitialState";

		public const string LanguageFileName = "Language";
		public const string LanguagesDirectoryResourcePath = "Languages";

		public const string OptionIdLanguage = "Language";
		public const string OptionIdEffectVolume = "EffectVolume";
		public const string OptionIdMasterVolume = "MasterVolume";
		public const string OptionIdSongVolume = "SongVolume";
		public const string OptionIdVoiceVolume = "VoiceVolume";

		public const string OptionsFileExtension = ".xml";
		public const string OptionsFileName = "Options";

		public const float PixelsPerUnit = 1;

		public const string SceneMainMenu = "MainMenu";
		public const string SceneRoom = "Room";
		public const string SceneSplashScreen = "SplashScreen";

		public const string SortingLayerCharacter = "Character";
		public const string SortingLayerInventory = "Inventory";
		public const string SortingLayerInventoryItem = "InventoryItem";
		public const string SortingLayerItem = "Item";
		public const string SortingLayerMenu = "Menu";
		public const string SortingLayerRoomBackground = "RoomBackground";
		public const string SortingLayerRoomForeground = "RoomForeground";
		public const string SortingLayerSplashScreen = "SplashScreen";

		public const string StateFileExtension = ".xml";
		public const string StateFilesDirectoryPath = "States";

		public const float StopDistanceFactor = 0.2f;
		
		public const string StyleSpeech = "Speech";
		public const string StyleTooltip = "Tooltip";

		public const string XmlAttributeId = "id";
		public const string XmlNodeBoolean = "boolean";
		public const string XmlNodeCharacter = "character";
		public const string XmlNodeCurrentRoom = "current-room";
		public const string XmlNodeDirection = "direction";
		public const string XmlNodeFloat = "float";
		public const string XmlNodeHint = "hint";
		public const string XmlNodeInteger = "integer";
		public const string XmlNodeInventoryItem = "inventory-item";
		public const string XmlNodeItem = "item";
		public const string XmlNodeLanguage = "language";
		public const string XmlNodeLocation = "location";
		public const string XmlNodeOptions = "options";
		public const string XmlNodePlayerCharacter = "player-character";
		public const string XmlNodePosition = "position";
		public const string XmlNodeRoom = "room";
		public const string XmlNodeSpeech = "speech";
		public const string XmlNodeState = "state";
		public const string XmlNodeString = "string";
		public const string XmlNodeText = "text";
		public const string XmlNodeVoice = "voice";
		public const string XmlNodeX = "x";
		public const string XmlNodeY = "y";
		
		private static Parameters instance;

		public static Color GetCameraBackgroundColor() {
			return instance.GameParameters.Graphics.CameraBackgroundColor;
		}
		
		public static CharacterParameters GetCharacterParameters(string characterId) {
			return instance.GameParameters.Entities.Characters[characterId];
		}

		public static Texture2D GetClickTexture() {
			return instance.GameParameters.Graphics.Cursors.ClickTexture;
		}

		public static KeyCode[] GetCloseMenuKeys() {
			return instance.GameParameters.Controls.CloseMenuKeys;
		}
		
		public static Vector2 GetCursorPreferredSize() {
			return instance.GameParameters.Graphics.Cursors.CursorPreferredSize;
		}
		
		public static Texture2D GetDefaultFadeTexture() {
			return instance.GameParameters.Graphics.DefaultFadeTexture;
		}
		
		public static float GetDelayBetweenSongs() {
			return instance.GameParameters.Sounds.DelayBetweenSongs;
		}
		
		public static string GetGameDirectoryPath() {
			return instance.GameParameters.GameDirectoryPath;
		}
		
		public static float GetGamePreferredHeight() {
			return instance.GameParameters.Graphics.GamePreferredHeight;
		}
		
		public static float GetGamePreferredWidth() {
			return instance.GameParameters.Graphics.GamePreferredWidth;
		}
		
		public static AudioClip GetInventoryEffect() {
			return instance.GameParameters.Sounds.InventoryEffect;
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
		
		public static Texture2D GetLookTexture() {
			return instance.GameParameters.Graphics.Cursors.LookTexture;
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
		
		public static AudioClip GetMenuEffect() {
			return instance.GameParameters.Sounds.MenuEffect;
		}
		
		public static MenuParameters GetMenuParameters(string menuId) {
			return instance.GameParameters.Entities.Menus.Others[menuId];
		}
		
		public static string GetOptionsFilePath() {
			string gameDirectoryPath = GetGameDirectoryPath();
			return Utilities.GetFilePath(OptionsFileName, OptionsFileExtension, gameDirectoryPath);
		}
		
		public static KeyCode[] GetPauseGameKeys() {
			return instance.GameParameters.Controls.PauseGameKeys;
		}
		
		public static MenuParameters GetPauseMenuParameters() {
			return instance.GameParameters.Entities.Menus.Pause;
		}
		
		public static Texture2D GetPickUpTexture() {
			return instance.GameParameters.Graphics.Cursors.PickUpTexture;
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
		
		public static KeyCode[] GetSetNextOrderKeys() {
			return instance.GameParameters.Controls.SetNextOrderKeys;
		}
		
		public static KeyCode[] GetSetPreviousOrderKeys() {
			return instance.GameParameters.Controls.SetPreviousOrderKeys;
		}
		
		public static GUISkin GetSkin() {
			return instance.GameParameters.Graphics.Skin;
		}
		
		public static Texture2D GetSpeakTexture() {
			return instance.GameParameters.Graphics.Cursors.SpeakTexture;
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
		
		public static string GetStateFilesDirectoryPath() {
			string gameDirectoryPath = GetGameDirectoryPath();
			return Utilities.GetDirectoryPath(gameDirectoryPath, StateFilesDirectoryPath);
		}
		
		public static KeyCode[] GetToggleInventoryKeys() {
			return instance.GameParameters.Controls.ToggleInventoryKeys;
		}
		
		public static KeyCode[] GetUnselectInventoryItemKeys() {
			return instance.GameParameters.Controls.UnselectInventoryItemKeys;
		}
		
		public static Vector2 GetUsedInventoryItemPreferredSize() {
			return instance.GameParameters.Graphics.Cursors.UsedInventoryItemPreferredSize;
		}
		
		public static Texture2D GetWalkTexture() {
			return instance.GameParameters.Graphics.Cursors.WalkTexture;
		}
		
		public static Texture2D GetWindowboxTexture() {
			return instance.GameParameters.Graphics.WindowboxTexture;
		}
		
		public static bool ShuffleSongs() {
			return instance.GameParameters.Sounds.ShuffleSongs;
		}
		
		public static bool UseMouseWheel() {
			return instance.GameParameters.Controls.UseMouseWheel;
		}
		
		public GameParameters GameParameters;
		
		public override void Awake() {
			base.Awake();
			instance = this;
		}

	}
	
}
