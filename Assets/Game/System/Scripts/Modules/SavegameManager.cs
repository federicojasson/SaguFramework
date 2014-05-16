using System.Xml.Linq;
using UnityEngine;

public static class SavegameManager {

	public static void LoadGame() {
		TextAsset textAsset = (TextAsset) Resources.Load(P.FILE_PATH_SAVEGAME, typeof(TextAsset));
		XElement root = XDocument.Parse(textAsset.text).Root;

		string currentRoomId = null;

		foreach (XElement node in root.Elements())
			switch (node.Name.LocalName) {
				case "character" : {
					string id = node.Element("id").Value.Trim();
					string roomId = node.Element("room-id").Value.Trim();
					XElement positionNode = node.Element("position");
					float x = Utility.ToFloat(positionNode.Element("x").Value.Trim());
					float y = Utility.ToFloat(positionNode.Element("y").Value.Trim());
					Vector2 position = new Vector2(x, y);
					Character character = new Character(id, roomId, position);
					CharacterManager.AddCharacter(character);
					break;
				}
				
				case "current-room-id" : {
					currentRoomId = node.Value.Trim();
					break;
				}
				
				case "inventory-item" : {
					string id = node.Element("id").Value.Trim();
					InventoryItem inventoryItem = new InventoryItem(id);
					ItemManager.AddInventoryItem(inventoryItem);
					break;
				}
				
				case "room-item" : {
					string id = node.Element("id").Value.Trim();
					string roomId = node.Element("room-id").Value.Trim();
					XElement positionNode = node.Element("position");
					float x = Utility.ToFloat(positionNode.Element("x").Value.Trim());
					float y = Utility.ToFloat(positionNode.Element("y").Value.Trim());
					Vector2 position = new Vector2(x, y);
					RoomItem roomItem = new RoomItem(id, roomId, position);
					ItemManager.AddRoomItem(roomItem);
					break;
				}
			}

		// Loads the current room
		RoomManager.LoadRoom(currentRoomId);
	}
	
	public static void NewGame() {
		// TODO
	}

	public static void SaveGame() {
		// TODO: rewrite Savegame.xml according to current state: call other modules
	}
	
}
