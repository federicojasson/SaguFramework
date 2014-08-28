using System.IO;
using System.Xml.Linq;

namespace SaguFramework {
	
	public static partial class StateManager {

		public static string[] GetStateIds() {
			// TODO: errors, exceptions?
			
			// Gets the state files
			FileInfo[] stateFiles = UtilityManager.GetDirectoryFiles(ParameterManager.GetStateFilesDirectoryPath(), ParameterManager.StateFileExtension);
			
			// Orders the state files by last write time (in descending order)
			FileInfo[] orderedStateFiles = UtilityManager.OrderFilesByLastWriteTimeDescending(stateFiles);
			
			// Gets the state IDs (that is, the file's name without its extension)
			string[] stateIds = new string[orderedStateFiles.Length];
			for (int i = 0; i < orderedStateFiles.Length; i++)
				stateIds[i] = UtilityManager.GetFileNameWithoutExtension(orderedStateFiles[i]);
			
			return stateIds;
		}

		public static void LoadInitialState() {
			// Gets the initial state file resource path
			string resourcePath = ParameterManager.InitialStateFileResourcePath;

			// Reads the state file
			XDocument stateFile = UtilityManager.ReadResourceXmlFile(resourcePath);

			// Processes the state file
			ProcessStateFile(stateFile);
		}
		
		public static void LoadState(string stateId) {
			// TODO: errors, exceptions?

			// Gets the state file path
			string path = ParameterManager.GetStateFilePath(stateId);

			// Reads the state file
			XDocument stateFile = UtilityManager.ReadXmlFile(path);

			// Processes the state file
			ProcessStateFile(stateFile);
		}

		public static void SaveState(string stateId) {
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
				SetPlayerCharacterId(playerCharacterId);
				SetCharacterLocation(playerCharacterId, playerCharacterLocation);
			}

			// Characters
			foreach (XElement characterNode in stateNode.Elements(ParameterManager.XmlTagCharacter)) {
				// Gets the character's ID and location
				XElement characterIdNode = characterNode.Element(ParameterManager.XmlTagId);
				string characterId = UtilityManager.GetXmlNodeStringValue(characterIdNode);
				XElement characterLocationNode = characterNode.Element(ParameterManager.XmlTagLocation);
				Location characterLocation = UtilityManager.GetXmlNodeLocationValue(characterLocationNode);

				// Sets the character's location
				SetCharacterLocation(characterId, characterLocation);
			}

			// Inventory items
			foreach (XElement inventoryItemNode in stateNode.Elements(ParameterManager.XmlTagInventoryItem)) {
				// Gets the inventory item's ID
				XElement inventoryItemIdNode = inventoryItemNode.Element(ParameterManager.XmlTagId);
				string inventoryItemId = UtilityManager.GetXmlNodeStringValue(inventoryItemIdNode);

				// Adds the inventory item
				AddInventoryItem(inventoryItemId);
			}

			// Items
			foreach (XElement itemNode in stateNode.Elements(ParameterManager.XmlTagItem)) {
				// Gets the item's ID and location
				XElement itemIdNode = itemNode.Element(ParameterManager.XmlTagId);
				string itemId = UtilityManager.GetXmlNodeStringValue(itemIdNode);
				XElement itemLocationNode = itemNode.Element(ParameterManager.XmlTagLocation);
				Location itemLocation = UtilityManager.GetXmlNodeLocationValue(itemLocationNode);
				
				// Sets the item's location
				SetItemLocation(itemId, itemLocation);
			}
		}
		
	}

}
