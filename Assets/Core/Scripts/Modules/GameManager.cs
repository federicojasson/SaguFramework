using System;
using System.Xml.Linq;
using UnityEngine;

//
// GameManager - Module class
//
// TODO: write class description
//
public static class GameManager {

	private static Menu pauseMenu;

	public static void LoadGame() {
		// TODO
	}

	public static void LoadNewGame() {
		TextAsset textFile = (TextAsset) Resources.Load(C.FILE_PATH_NEW_GAME_STATE, typeof(TextAsset));
		if (textFile == null)
			// The new game state file was not found
			ErrorManager.Terminate("GameManager", "The new game state file was not found");
		
		try {
			XElement root = XDocument.Parse(textFile.text).Root;

			string currentRoom = null;
			foreach (XElement node in root.Elements())
				switch (node.Name.LocalName) {
					case C.CHARACTER_TAG : {
						string id = node.Attribute(C.CHARACTER_ATTRIBUTE_ID).Value.Trim();
						string room = node.Element(C.CHARACTER_ROOM_TAG).Value.Trim();
						float x = Parser.StringToFloat(node.Element(C.CHARACTER_X_TAG).Value.Trim());
						float y = Parser.StringToFloat(node.Element(C.CHARACTER_Y_TAG).Value.Trim());
						Character character = new Character(id, room, x, y);
						CharacterManager.AddCharacter(character);
						break;
					}
					
					case C.CURRENT_ROOM_TAG : {
						currentRoom = node.Value.Trim();
						break;
					}
					
					case C.INVENTORY_ITEM_TAG : {
						string id = node.Attribute(C.INVENTORY_ITEM_ATTRIBUTE_ID).Value.Trim();
						InventoryItem item = new InventoryItem(id);
						InventoryManager.AddItem(item);
						break;
					}
					
					case C.ITEM_TAG : {
						string id = node.Attribute(C.ITEM_ATTRIBUTE_ID).Value.Trim();
						string room = node.Element(C.ITEM_ROOM_TAG).Value.Trim();
						float x = Parser.StringToFloat(node.Element(C.ITEM_X_TAG).Value.Trim());
						float y = Parser.StringToFloat(node.Element(C.ITEM_Y_TAG).Value.Trim());
						Item item = new Item(id, room, x, y);
						ItemManager.AddItem(item);
						break;
					}
				}

			// Loads the current room
			RoomManager.LoadRoom(currentRoom);
		} catch (Exception) {
			// The new game state file couldn't be parsed
			ErrorManager.Terminate("GameManager", "The new game state file couldn't be parsed");
		}
	}

	public static void PauseGame() {
		// Sets the input manager pause mode
		InputManager.SetMode(C.INPUT_MANAGER_MODE_PAUSE);

		// Shows the pause menu
		GUIManager.ShowMenu(pauseMenu);
	}

	public static void QuitGame() {
		Application.Quit();
	}

	public static void ResumeGame() {
		// Hides all menus and dialogs
		GUIManager.HideAll();
		
		// Sets the input manager play mode
		InputManager.SetMode(C.INPUT_MANAGER_MODE_PLAY);
	}
	
	public static void SaveGame() {
		// TODO: Resources folder is read-only. Figure it out somehow
	}

	public static void SetPauseMenu(Menu pauseMenu) {
		GameManager.pauseMenu = pauseMenu;
	}

}
