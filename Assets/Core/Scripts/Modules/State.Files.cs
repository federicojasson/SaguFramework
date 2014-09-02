using System.Collections.Generic;
using System.Xml.Linq;

namespace SaguFramework {
	
	public static partial class State {

		public static void LoadInitial() {
			string resourcePath = Parameters.InitialStateFileResourcePath;
			XDocument file = Utilities.ReadResourceXmlFile(resourcePath);
			ProcessStateFile(file);
		}
		
		public static void Load(string id) {
			// TODO: errors, exceptions?

			string path = Parameters.GetStateFilePath(id);
			XDocument file = Utilities.ReadXmlFile(path);
			ProcessStateFile(file);
		}

		public static void Save(string id) {
			XDocument file = GenerateStateFile();
			string path = Parameters.GetStateFilePath(id);
			Utilities.WriteXmlFile(path, file);
		}
		
		private static XDocument GenerateStateFile() {
			// State
			XElement stateNode = new XElement(Parameters.XmlTagState);
			
			// Current room
			{
				XElement currentRoomIdNode = new XElement(Parameters.XmlTagCurrentRoomId);
				Utilities.SetXmlNodeStringValue(currentRoomIdNode, currentRoomId);

				stateNode.Add(currentRoomIdNode);
			}

			// TODO: complete
			/*// Player character
			{
				XElement playerCharacterNode = new XElement(Parameters.XmlTagPlayerCharacter);

				XElement playerCharacterIdNode = new XElement(Parameters.XmlTagId);
				Utilities.SetXmlNodeStringValue(playerCharacterIdNode, playerCharacterId);

				Location playerCharacterLocation = characterLocations[playerCharacterId];

				XElement playerCharacterLocationNode = new XElement(Parameters.XmlTagLocation);
				Utilities.SetXmlNodeLocationValue(playerCharacterLocationNode, playerCharacterLocation);

				playerCharacterNode.Add(playerCharacterIdNode, playerCharacterLocationNode);
				stateNode.Add(playerCharacterNode);
			}
			
			// Inventory page
			{
				XElement inventoryPageNode = new XElement(Parameters.XmlTagInventoryPage);
				Utilities.SetXmlNodeIntegerValue(inventoryPageNode, inventoryPage);

				stateNode.Add(inventoryPageNode);
			}*/
			
			// Hints
			foreach (string hint in hints) {
				XElement hintNode = new XElement(Parameters.XmlTagHint);
				Utilities.SetXmlNodeStringValue(hintNode, hint);

				stateNode.Add(hintNode);
			}
			
			/*// Inventory items
			foreach (string inventoryItemId in inventoryItemIds) {
				XElement inventoryItemNode = new XElement(Parameters.XmlTagInventoryItem);

				XElement inventoryItemIdNode = new XElement(Parameters.XmlTagId);
				Utilities.SetXmlNodeStringValue(inventoryItemIdNode, inventoryItemId);

				inventoryItemNode.Add(inventoryItemIdNode);
				stateNode.Add(inventoryItemNode);
			}
			
			// Characters
			foreach (KeyValuePair<string, Location> entry in characterLocations) {
				XElement characterNode = new XElement(Parameters.XmlTagCharacter);

				XElement characterIdNode = new XElement(Parameters.XmlTagId);
				Utilities.SetXmlNodeStringValue(characterIdNode, entry.Key);

				XElement characterLocationNode = new XElement(Parameters.XmlTagLocation);
				Utilities.SetXmlNodeLocationValue(characterLocationNode, entry.Value);

				characterNode.Add(characterIdNode, characterLocationNode);
				stateNode.Add(characterNode);
			}*/
			
			// Items
			foreach (KeyValuePair<string, ItemState> entry in itemStates) {
				XElement itemNode = new XElement(Parameters.XmlTagItem);

				XElement idNode = new XElement(Parameters.XmlTagId);
				Utilities.SetXmlNodeStringValue(idNode, entry.Key);
				
				ItemState state = entry.Value;

				XElement locationNode = new XElement(Parameters.XmlTagLocation);
				Utilities.SetXmlNodeLocationValue(locationNode, state.GetLocation());

				itemNode.Add(idNode, locationNode);
				stateNode.Add(itemNode);
			}
			
			// Initializes and returns the state file
			return new XDocument(stateNode);
		}
		
		private static void ProcessStateFile(XDocument stateFile) {
			currentRoomId = null;
			/*playerCharacterId = null;
			inventoryPage = 0;
			characterLocations.Clear();
			inventoryItemIds.Clear();*/
			itemStates.Clear();
			
			// State
			XElement stateNode = stateFile.Element(Parameters.XmlTagState);
			
			// Current room
			{
				XElement currentRoomIdNode = stateNode.Element(Parameters.XmlTagCurrentRoomId);
				currentRoomId = Utilities.GetXmlNodeStringValue(currentRoomIdNode);
			}

			// TODO: uncomment
			/*// Player character
			{
				XElement playerCharacterNode = stateNode.Element(Parameters.XmlTagPlayerCharacter);
				XElement playerCharacterIdNode = playerCharacterNode.Element(Parameters.XmlTagId);
				playerCharacterId = Utilities.GetXmlNodeStringValue(playerCharacterIdNode);

				XElement playerCharacterLocationNode = playerCharacterNode.Element(Parameters.XmlTagLocation);
				Location playerCharacterLocation = Utilities.GetXmlNodeLocationValue(playerCharacterLocationNode);

				characterLocations[playerCharacterId] = playerCharacterLocation;
			}
			
			// Inventory page
			{
				XElement inventoryPageNode = stateNode.Element(Parameters.XmlTagInventoryPage);
				inventoryPage = Utilities.GetXmlNodeIntegerValue(inventoryPageNode);
			}*/
			
			// Hints
			foreach (XElement hintNode in stateNode.Elements(Parameters.XmlTagHint)) {
				string hint = Utilities.GetXmlNodeStringValue(hintNode);

				hints.Add(hint);
			}
			
			/*// Inventory items
			foreach (XElement inventoryItemNode in stateNode.Elements(Parameters.XmlTagInventoryItem)) {
				XElement inventoryItemIdNode = inventoryItemNode.Element(Parameters.XmlTagId);
				string inventoryItemId = Utilities.GetXmlNodeStringValue(inventoryItemIdNode);

				inventoryItemIds.Add(inventoryItemId);
			}
			
			// Characters
			foreach (XElement characterNode in stateNode.Elements(Parameters.XmlTagCharacter)) {
				XElement characterIdNode = characterNode.Element(Parameters.XmlTagId);
				string characterId = Utilities.GetXmlNodeStringValue(characterIdNode);
				XElement characterLocationNode = characterNode.Element(Parameters.XmlTagLocation);
				Location characterLocation = Utilities.GetXmlNodeLocationValue(characterLocationNode);

				characterLocations[characterId] = characterLocation;
			}*/
			
			// Items
			foreach (XElement itemNode in stateNode.Elements(Parameters.XmlTagItem)) {
				XElement idNode = itemNode.Element(Parameters.XmlTagId);
				string id = Utilities.GetXmlNodeStringValue(idNode);
				XElement locationNode = itemNode.Element(Parameters.XmlTagLocation);
				Location location = Utilities.GetXmlNodeLocationValue(locationNode);

				ItemState state = new ItemState(location);

				itemStates[id] = state;
			}
		}

	}
	
}
