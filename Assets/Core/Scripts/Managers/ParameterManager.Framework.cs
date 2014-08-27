namespace SaguFramework {
	
	public static partial class ParameterManager {
		
		// TODO: usar esta clase para obtener parametros del framework

		public const float PixelsPerUnit = 1;

		public const string SceneMain = "Main";
		public const string SceneMainMenu = "MainMenu";
		public const string SceneRoom = "Room";
		public const string SceneSpecial = "Special";
		public const string SceneSplashScreen = "SplashScreen";

		public const string SortingLayerCharacterImage = "CharacterImage";
		public const string SortingLayerInventoryImage = "InventoryImage";
		public const string SortingLayerInventoryItemImage = "InventoryItemImage";
		public const string SortingLayerItemImage = "ItemImage";
		public const string SortingLayerMenuBackgroundImage = "MenuBackgroundImage";
		public const string SortingLayerRoomBackgroundImage = "RoomBackgroundImage";
		public const string SortingLayerRoomForegroundImage = "RoomForegroundImage";
		public const string SortingLayerSplashScreenImage = "SplashScreenImage";

		public const string StateFileExtension = ".xml";

		public const string XmlTagCharacter = "character";
		public const string XmlTagCurrentRoomId = "current-room-id";
		public const string XmlTagId = "id";
		public const string XmlTagInventoryItem = "inventory-item";
		public const string XmlTagItem = "item";
		public const string XmlTagLocation = "location";
		public const string XmlTagPlayerCharacter = "player-character";
		public const string XmlTagPositionInGame = "position-in-game";
		public const string XmlTagRoomId = "room-id";
		public const string XmlTagState = "state";
		public const string XmlTagX = "x";
		public const string XmlTagY = "y";
		
		public static string GetStateFilePath(string stateId) {
			// Gets the state files' directory path
			string stateFilesDirectoryPath = ParameterManager.GetStateFilesDirectoryPath();

			// Gets the extension used for the state files
			string stateFileExtension = ParameterManager.StateFileExtension;

			// Gets the resulting path and returns it
			return UtilityManager.GetPath(stateFilesDirectoryPath, stateId, stateFileExtension);
		}
		
	}
	
}
