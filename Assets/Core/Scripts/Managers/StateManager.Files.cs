using System.Collections.Generic;
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
			// Generates the state file
			XDocument stateFile = GenerateStateFile();

			// Gets the corresponding state file's path
			string path = ParameterManager.GetStateFilePath(stateId);

			// Writes the state file
			UtilityManager.WriteXmlFile(path, stateFile);
		}

		private static XDocument GenerateStateFile() {
			// State
			XElement stateNode = new XElement(ParameterManager.XmlTagState);
			
			// Current room
			{
				// Sets the current room's ID
				XElement currentRoomIdNode = new XElement(ParameterManager.XmlTagCurrentRoomId);
				UtilityManager.SetXmlNodeStringValue(currentRoomIdNode, currentRoomId);
				
				// Connects the nodes
				stateNode.Add(currentRoomIdNode);
			}
			
			// Player character
			{
				XElement playerCharacterNode = new XElement(ParameterManager.XmlTagPlayerCharacter);
				
				// Sets the player character's ID
				XElement playerCharacterIdNode = new XElement(ParameterManager.XmlTagId);
				UtilityManager.SetXmlNodeStringValue(playerCharacterIdNode, playerCharacterId);
				
				// Gets the player character's location
				Location playerCharacterLocation = characterLocations[playerCharacterId];
				
				// Sets the player character's location
				XElement playerCharacterLocationNode = new XElement(ParameterManager.XmlTagLocation);
				UtilityManager.SetXmlNodeLocationValue(playerCharacterLocationNode, playerCharacterLocation);
				
				// Connects the nodes
				playerCharacterNode.Add(playerCharacterIdNode, playerCharacterLocationNode);
				stateNode.Add(playerCharacterNode);
			}

			// Inventory page
			{
				// Sets the inventory's page
				XElement inventoryPageNode = new XElement(ParameterManager.XmlTagInventoryPage);
				UtilityManager.SetXmlNodeIntegerValue(inventoryPageNode, inventoryPage);
				
				// Connects the nodes
				stateNode.Add(inventoryPageNode);
			}
			
			// Inventory items
			foreach (string inventoryItemId in inventoryItemIds) {
				XElement inventoryItemNode = new XElement(ParameterManager.XmlTagInventoryItem);
				
				// Sets the inventory item's ID
				XElement inventoryItemIdNode = new XElement(ParameterManager.XmlTagId);
				UtilityManager.SetXmlNodeStringValue(inventoryItemIdNode, inventoryItemId);
				
				// Connects the nodes
				inventoryItemNode.Add(inventoryItemIdNode);
				stateNode.Add(inventoryItemNode);
			}
			
			// Characters
			foreach (KeyValuePair<string, Location> entry in characterLocations) {
				XElement characterNode = new XElement(ParameterManager.XmlTagCharacter);
				
				// Sets the character's ID
				XElement characterIdNode = new XElement(ParameterManager.XmlTagId);
				UtilityManager.SetXmlNodeStringValue(characterIdNode, entry.Key);
				
				// Sets the character's location
				XElement characterLocationNode = new XElement(ParameterManager.XmlTagLocation);
				UtilityManager.SetXmlNodeLocationValue(characterLocationNode, entry.Value);
				
				// Connects the nodes
				characterNode.Add(characterIdNode, characterLocationNode);
				stateNode.Add(characterNode);
			}
			
			// Items
			foreach (KeyValuePair<string, Location> entry in itemLocations) {
				XElement itemNode = new XElement(ParameterManager.XmlTagItem);
				
				// Sets the item's ID
				XElement itemIdNode = new XElement(ParameterManager.XmlTagId);
				UtilityManager.SetXmlNodeStringValue(itemIdNode, entry.Key);
				
				// Sets the item's location
				XElement itemLocationNode = new XElement(ParameterManager.XmlTagLocation);
				UtilityManager.SetXmlNodeLocationValue(itemLocationNode, entry.Value);
				
				// Connects the nodes
				itemNode.Add(itemIdNode, itemLocationNode);
				stateNode.Add(itemNode);
			}
			
			// Initializes and returns the state file
			return new XDocument(stateNode);
		}

		private static void ProcessStateFile(XDocument stateFile) {
			// Nullify the current room and player character's IDs
			currentRoomId = null;
			playerCharacterId = null;
			
			// Resets the inventory page
			inventoryPage = 0;

			// Clears the data structures
			characterLocations.Clear();
			inventoryItemIds.Clear();
			itemLocations.Clear();

			// State
			XElement stateNode = stateFile.Element(ParameterManager.XmlTagState);

			// Current room
			{
				// Gets the current room's ID
				XElement currentRoomIdNode = stateNode.Element(ParameterManager.XmlTagCurrentRoomId);
				currentRoomId = UtilityManager.GetXmlNodeStringValue(currentRoomIdNode);
			}

			// Player character
			{
				// Gets the player character's ID
				XElement playerCharacterNode = stateNode.Element(ParameterManager.XmlTagPlayerCharacter);
				XElement playerCharacterIdNode = playerCharacterNode.Element(ParameterManager.XmlTagId);
				playerCharacterId = UtilityManager.GetXmlNodeStringValue(playerCharacterIdNode);

				// Gets the player character's location
				XElement playerCharacterLocationNode = playerCharacterNode.Element(ParameterManager.XmlTagLocation);
				Location playerCharacterLocation = UtilityManager.GetXmlNodeLocationValue(playerCharacterLocationNode);

				// Sets the player character's location
				characterLocations[playerCharacterId] = playerCharacterLocation;
			}

			// Inventory page
			{
				// Gets the inventory page
				XElement inventoryPageNode = stateNode.Element(ParameterManager.XmlTagInventoryPage);
				inventoryPage = UtilityManager.GetXmlNodeIntegerValue(inventoryPageNode);
			}
			
			// Inventory items
			foreach (XElement inventoryItemNode in stateNode.Elements(ParameterManager.XmlTagInventoryItem)) {
				// Gets the inventory item's ID
				XElement inventoryItemIdNode = inventoryItemNode.Element(ParameterManager.XmlTagId);
				string inventoryItemId = UtilityManager.GetXmlNodeStringValue(inventoryItemIdNode);
				
				// Adds the inventory item
				inventoryItemIds.Add(inventoryItemId);
			}

			// Characters
			foreach (XElement characterNode in stateNode.Elements(ParameterManager.XmlTagCharacter)) {
				// Gets the character's ID and location
				XElement characterIdNode = characterNode.Element(ParameterManager.XmlTagId);
				string characterId = UtilityManager.GetXmlNodeStringValue(characterIdNode);
				XElement characterLocationNode = characterNode.Element(ParameterManager.XmlTagLocation);
				Location characterLocation = UtilityManager.GetXmlNodeLocationValue(characterLocationNode);

				// Sets the character's location
				characterLocations[characterId] = characterLocation;
			}

			// Items
			foreach (XElement itemNode in stateNode.Elements(ParameterManager.XmlTagItem)) {
				// Gets the item's ID and location
				XElement itemIdNode = itemNode.Element(ParameterManager.XmlTagId);
				string itemId = UtilityManager.GetXmlNodeStringValue(itemIdNode);
				XElement itemLocationNode = itemNode.Element(ParameterManager.XmlTagLocation);
				Location itemLocation = UtilityManager.GetXmlNodeLocationValue(itemLocationNode);
				
				// Sets the item's location
				itemLocations[itemId] = itemLocation;
			}
		}
		
	}

}
