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
		RoomManager.SetCurrentRoom(room);
		Application.LoadLevel(room);
	}

	public static void LoadRoomWithSplashScreen(string room) {
		RoomManager.SetCurrentRoom(room);
		Application.LoadLevel(ConfigurationManager.SplashScreenScene);
	}

	public static void LoadState(string stateFilePath) {
		string stateFileContent = ""; //TODO: fill somehow

		XElement root = XDocument.Parse(stateFileContent).Root;

		foreach (XElement node in root.Elements())
		switch (node.Name.LocalName) {
			case ConfigurationManager.XmlTagCharacter : {
				// TODO: CharacterManager.RegisterCharacterLocation();
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
				// TODO: CharacterManager.RegisterItemLocation();
				break;
			}
		}
	}

}
