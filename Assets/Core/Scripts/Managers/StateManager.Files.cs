using System.Xml.Linq;

namespace SaguFramework {
	
	public static partial class StateManager {
		
		public static void ReadInitialStateFile() {
			// Gets the initial state file path
			string resourcePath = ParameterManager.InitialStateFileResourcePath;

			// Reads the state file
			XDocument stateFile = UtilityManager.ReadResourceXmlFile(resourcePath);

			// Processes the state file
			ProcessStateFile(stateFile);

			// TODO
		}
		
		public static void ReadStateFile(string stateId) {
			// TODO
		}

		public static void WriteStateFile(string stateId) {
			// TODO: fill stateNode and comment
			XElement stateNode = new XElement(ParameterManager.XmlTagState);

			// Initializes the state file
			XDocument stateFile = new XDocument(stateNode);

			// Gets the corresponding state file's path
			string path = ParameterManager.GetStateFilePath(stateId);

			// Writes the state file
			UtilityManager.WriteXmlFile(path, stateFile);
		}

		private static void ProcessStateFile(XDocument stateFile) {
			// Nullify the current room and player character's IDs
			StateManager.currentRoomId = null;
			StateManager.playerCharacterId = null;

			// Clears the data structures
			characterLocations.Clear();
			inventoryItemIds.Clear();
			itemLocations.Clear();

			// Gets the root node
			XElement stateNode = stateFile.Element(ParameterManager.XmlTagState);

			// Current room
			{
				// Gets the current room's ID
				XElement currentRoomIdNode = stateNode.Element(ParameterManager.XmlTagCurrentRoomId);
				string currentRoomId = UtilityManager.GetXmlNodeStringValue(currentRoomIdNode);

				// Sets the current room's ID
				SetCurrentRoomId(currentRoomId);
			}

			// Player character
			{
				// Gets the player character's ID and location
				XElement playerCharacterNode = stateNode.Element(ParameterManager.XmlTagPlayerCharacter);
				XElement playerCharacterIdNode = playerCharacterNode.Element(ParameterManager.XmlTagId);
				string playerCharacterId = UtilityManager.GetXmlNodeStringValue(playerCharacterIdNode);
				XElement playerCharacterLocationNode = playerCharacterNode.Element(ParameterManager.XmlTagLocation);
				Location playerCharacterLocation = UtilityManager.GetXmlNodeLocationValue(playerCharacterLocationNode);

				// Sets the player character's ID and location
				StateManager.SetPlayerCharacterId(playerCharacterId);
				StateManager.SetCharacterLocation(playerCharacterId, playerCharacterLocation);
			}

			// Characters
			foreach (XElement characterNode in stateNode.Elements(ParameterManager.XmlTagCharacter)) {
				XElement characterIdNode = characterNode.Element(ParameterManager.XmlTagId);
				string characterId = UtilityManager.GetXmlNodeStringValue(characterIdNode);
				XElement characterLocationNode = characterNode.Element(ParameterManager.XmlTagLocation);
				Location characterLocation = UtilityManager.GetXmlNodeLocationValue(characterLocationNode);
				
				StateManager.SetCharacterLocation(characterId, characterLocation);
			}

			// Inventory items
			foreach (XElement inventoryItemNode in stateNode.Elements(ParameterManager.XmlTagInventoryItem)) {
				XElement inventoryItemIdNode = inventoryItemNode.Element(ParameterManager.XmlTagId);
				string inventoryItemId = UtilityManager.GetXmlNodeStringValue(inventoryItemIdNode);

				StateManager.AddInventoryItem(inventoryItemId);
			}

			// Items
			foreach (XElement itemNode in stateNode.Elements(ParameterManager.XmlTagItem)) {
				XElement itemIdNode = itemNode.Element(ParameterManager.XmlTagId);
				string itemId = UtilityManager.GetXmlNodeStringValue(itemIdNode);
				XElement itemLocationNode = itemNode.Element(ParameterManager.XmlTagLocation);
				Location itemLocation = UtilityManager.GetXmlNodeLocationValue(itemLocationNode);
				
				StateManager.SetItemLocation(itemId, itemLocation);
			}
		}
		
	}

}
