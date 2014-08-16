using System.IO;
using System.Xml.Linq;
using UnityEngine;

public static class StateManager {

	public static void CreateCurrentRoom() {
		string currentRoomId = RoomManager.GetCurrentRoomId();

		RoomManager.CreateRoom(currentRoomId);
		CharacterManager.CreateRoomCharacters(currentRoomId);
		ItemManager.CreateRoomItems(currentRoomId);
	}
	
	public static void LoadCurrentRoom() {
		Application.LoadLevel(ConfigurationManager.SceneRoom);
	}
	
	public static void LoadInitialState() {
		string stateFileContent = UtilityManager.ReadResourceTextFileContent(ConfigurationManager.InitialStateFileResourcePath);
		LoadStateFromContent(stateFileContent);
	}

	public static void LoadMainMenu() {
		Application.LoadLevel(ConfigurationManager.SceneMainMenu);
	}

	public static void LoadRoom(string roomId) {
		if (ConfigurationManager.UseSplashScreens)
			LoadRoomWithSplashScreen(roomId);
		else
			LoadRoomWithoutSplashScreen(roomId);
	}

	public static void LoadState(string stateFileId) {
		string stateFilePath = "";
		stateFilePath += ConfigurationManager.StateFilesDirectoryPath;
		stateFilePath += Path.DirectorySeparatorChar;
		stateFilePath += stateFileId;
		stateFilePath += ConfigurationManager.StateFileExtension;

		string stateFileContent = UtilityManager.ReadTextFileContent(stateFilePath);
		LoadStateFromContent(stateFileContent);
	}
	
	private static void LoadRoomWithSplashScreen(string roomId) {
		RoomManager.SetCurrentRoomId(roomId);
		Application.LoadLevel(ConfigurationManager.SceneSplashScreen);
	}
	
	private static void LoadRoomWithoutSplashScreen(string roomId) {
		RoomManager.SetCurrentRoomId(roomId);
		Application.LoadLevel(ConfigurationManager.SceneRoom);
	}

	private static void LoadStateFromContent(string stateFileContent) {
		CharacterManager.ClearState();
		ItemManager.ClearState();
		RoomManager.ClearState();
		
		XElement root = XDocument.Parse(stateFileContent).Root;
		
		string currentRoomId = ReadXmlCurrentRoomId(root);
		RoomManager.SetCurrentRoomId(currentRoomId);

		foreach (XElement node in root.Elements(ConfigurationManager.XmlTagCharacter)) {
			string id = ReadXmlId(node);
			Location location = ReadXmlLocation(node);
			
			CharacterManager.SetCharacterLocation(id, location);

			if (node.Attribute(ConfigurationManager.XmlAttributePlayerCharacter) != null)
				CharacterManager.SetPlayerCharacterId(id);
		}

		foreach (XElement node in root.Elements(ConfigurationManager.XmlTagInventoryItem)) {
			string id = ReadXmlId(node);

			// TODO
		}

		foreach (XElement node in root.Elements(ConfigurationManager.XmlTagItem)) {
			string id = ReadXmlId(node);
			Location location = ReadXmlLocation(node);
			
			ItemManager.SetItemLocation(id, location);
		}
		
		LoadRoom(RoomManager.GetCurrentRoomId());
	}
	
	private static string ReadXmlCurrentRoomId(XElement parentNode) {
		XElement node = parentNode.Element(ConfigurationManager.XmlTagCurrentRoomId);
		return node.Value.Trim();
	}

	private static string ReadXmlId(XElement parentNode) {
		XElement node = parentNode.Element(ConfigurationManager.XmlTagId);
		return node.Value.Trim();
	}

	private static Location ReadXmlLocation(XElement parentNode) {
		XElement node = parentNode.Element(ConfigurationManager.XmlTagLocation);

		string roomId = ReadXmlRoomId(node);
		Vector2 position = ReadXmlPosition(node);

		return new Location(roomId, position);
	}

	private static Vector2 ReadXmlPosition(XElement parentNode) {
		XElement node = parentNode.Element(ConfigurationManager.XmlTagPosition);

		float x = ReadXmlX(node);
		float y = ReadXmlY(node);

		return new Vector2(x, y);
	}

	private static string ReadXmlRoomId(XElement parentNode) {
		XElement node = parentNode.Element(ConfigurationManager.XmlTagRoomId);
		return node.Value.Trim();
	}

	private static float ReadXmlX(XElement parentNode) {
		XElement node = parentNode.Element(ConfigurationManager.XmlTagX);
		
		string xString = node.Value.Trim();
		
		return UtilityManager.StringToFloat(xString);
	}

	private static float ReadXmlY(XElement parentNode) {
		XElement node = parentNode.Element(ConfigurationManager.XmlTagY);

		string yString = node.Value.Trim();

		return UtilityManager.StringToFloat(yString);
	}

}
