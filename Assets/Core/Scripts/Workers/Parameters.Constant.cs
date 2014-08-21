using UnityEngine;

public partial class Parameters : MonoBehaviour {

	// TODO: order this
	public const string StateFilesExtension = ".xml";
	public const string LanguagesDirectoryResourcePath = "Languages";
	public const string LanguageFilename = "Language";
	
	public const string InitialOptionsFileResourcePath = "InitialOptions";
	public const string InitialStateFileResourcePath = "InitialState";


	// Sorting layers
	
	public const string CharacterBackgroundSortingLayer = "CharacterBackground";
	public const string ItemBackgroundSortingLayer = "ItemBackground";
	public const string MenuBackgroundSortingLayer = "MenuBackground";
	public const string RoomBackgroundSortingLayer = "RoomBackground";
	public const string RoomForegroundSortingLayer = "RoomForeground";
	public const string SplashScreenBackgroundSortingLayer = "SplashScreenBackground";


	// Scenes

	public const string MainScene = "Main";
	public const string MainMenuScene = "MainMenu";
	public const string RoomScene = "Room";
	public const string SpecialScene = "Special";
	public const string SplashScreenScene = "SplashScreen";


	// Xml

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
	public const string XmlTagRoomId = "room-id";
	public const string XmlTagPosition = "position";
	public const string XmlTagX = "x";
	public const string XmlTagY = "y";
	
}
