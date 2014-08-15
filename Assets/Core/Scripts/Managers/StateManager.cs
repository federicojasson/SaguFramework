using System.IO;
using System.Xml.Linq;
using UnityEngine;

public static class StateManager {

	public static void LoadCurrentRoom() {
		Application.LoadLevel(RoomManager.GetCurrentRoom());
	}
	
	public static void LoadCurrentRoomResources() {
		string currentRoom = RoomManager.GetCurrentRoom();

		CharacterManager.CreateRoomCharacters(currentRoom);
		ItemManager.CreateRoomItems(currentRoom);
	}

	public static void LoadMainMenu() {
		Application.LoadLevel(ConfigurationManager.MainMenuScene);
	}

	public static void LoadRoom(string room) {
		if (ConfigurationManager.UseSplashScreens)
			LoadRoomWithSplashScreen(room);
		else
			LoadRoomWithoutSplashScreen(room);
	}

	public static void LoadState(string stateFileId) {
		CharacterManager.ClearState();
		ItemManager.ClearState();
		RoomManager.ClearState();

		string stateFileContent = ReadStateFileContent(stateFileId);

		XElement root = XDocument.Parse(stateFileContent).Root;

		foreach (XElement node in root.Elements())
		switch (node.Name.LocalName) {
			case ConfigurationManager.XmlTagCharacter : {
				string id = ReadXmlId(node);
				Location location = ReadXmlLocation(node);

				CharacterManager.SetCharacterLocation(id, location);

				if (node.Attribute(ConfigurationManager.XmlAttributePlayerCharacter) != null)
					CharacterManager.SetPlayerCharacterId(id);

				break;
			}

			case ConfigurationManager.XmlTagCurrentRoom : {
				RoomManager.SetCurrentRoom(node.Value.Trim());
				break;
			}

			case ConfigurationManager.XmlTagInventoryItem : {
				// TODO
				break;
			}

			case ConfigurationManager.XmlTagItem : {
				string id = ReadXmlId(node);
				Location location = ReadXmlLocation(node);

				ItemManager.SetItemLocation(id, location);
				break;
			}
		}

		LoadRoom(RoomManager.GetCurrentRoom());
	}
	
	private static void LoadRoomWithSplashScreen(string room) {
		RoomManager.SetCurrentRoom(room);
		Application.LoadLevel(ConfigurationManager.SplashScreenScene);
	}
	
	private static void LoadRoomWithoutSplashScreen(string room) {
		RoomManager.SetCurrentRoom(room);
		Application.LoadLevel(room);
	}

	private static string ReadStateFileContent(string stateFileId) {
		// Computes the state file path
		string stateFilePath = "";
		stateFilePath += ConfigurationManager.StateFilesDirectoryPath;
		stateFilePath += Path.DirectorySeparatorChar;
		stateFilePath += stateFileId;
		stateFilePath += ConfigurationManager.StateFileExtension;

		// Reads the state file
		return UtilityManager.ReadTextFileContent(stateFilePath);
	}

	private static string ReadXmlId(XElement parentNode) {
		XElement node = parentNode.Element(ConfigurationManager.XmlTagId);
		return node.Value.Trim();
	}

	private static Location ReadXmlLocation(XElement parentNode) {
		XElement node = parentNode.Element(ConfigurationManager.XmlTagLocation);

		string room = ReadXmlRoom(node);
		Vector2 position = ReadXmlPosition(node);

		return new Location(room, position);
	}

	private static Vector2 ReadXmlPosition(XElement parentNode) {
		XElement node = parentNode.Element(ConfigurationManager.XmlTagPosition);

		float x = ReadXmlX(node);
		float y = ReadXmlY(node);

		return new Vector2(x, y);
	}

	private static string ReadXmlRoom(XElement parentNode) {
		XElement node = parentNode.Element(ConfigurationManager.XmlTagRoom);
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
