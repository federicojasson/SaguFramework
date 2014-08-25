using UnityEngine;

public partial class Parameters : MonoBehaviour {

	// TODO: order this
	public const float PixelsPerUnit = 1;

	public const string StateFilesExtension = ".xml";
	public const string LanguagesDirectoryResourcePath = "Languages";
	public const string LanguageFilename = "Language";

	public const string ImageObjectName = "ImageObject";

	public const string InitialOptionsFileResourcePath = "InitialOptions";
	public const string InitialStateFileResourcePath = "InitialState";
	public const string LanguageOptionId = "Language";

	public const string MainMenuId = "MainMenu";
	public const string MainSplashScreenId = "MainSplashScreen";
	public const string RoomSplashScreenGroupId = "RoomSplashScreens";


	// Sorting layers
	
	public const string CharacterImageSortingLayer = "CharacterImage";
	public const string FadeImageSortingLayer = "FadeImage";
	public const string InventoryImageSortingLayer = "InventoryImage";
	public const string InventoryItemImageSortingLayer = "InventoryItemImage";
	public const string ItemImageSortingLayer = "ItemImage";
	public const string MenuImageSortingLayer = "MenuImage";
	public const string RoomBackgroundImageSortingLayer = "RoomBackgroundImage";
	public const string RoomForegroundImageSortingLayer = "RoomForegroundImage";
	public const string SplashScreenImageSortingLayer = "SplashScreenImage";


	// Scenes

	public const string MainScene = "Main";
	public const string MainMenuScene = "MainMenu";
	public const string RoomScene = "Room";
	public const string SpecialScene = "Special";
	public const string SplashScreenScene = "SplashScreen";


	// Xml

	public const string XmlTagState = "state";
	public const string XmlTagOptions = "options";
	public const string XmlTagText = "text";
	public const string XmlTagId = "id";
	public const string XmlTagValue = "value";

	public const string XmlTagAudio = "audio";
	public const string XmlTagResourcePath = "resource-path";

	public const string XmlTagBoolean = "boolean";

	public const string XmlTagFloat = "float";

	public const string XmlTagInteger = "integer";

	public const string XmlTagString = "string";

	public const string XmlTagCharacter = "character";
	public const string XmlTagCurrentRoomId = "current-room-id";
	public const string XmlTagInventoryItem = "inventory-item";
	public const string XmlTagItem = "item";
	public const string XmlTagPlayerCharacter = "player-character";

	public const string XmlTagLocation = "location";
	public const string XmlTagPositionInGame = "position-in-game";
	public const string XmlTagRoomId = "room-id";
	public const string XmlTagX = "x";
	public const string XmlTagY = "y";
	
}
