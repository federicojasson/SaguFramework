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

			// Player character ID
			{
				XElement playerCharacterIdNode = new XElement(Parameters.XmlTagPlayerCharacterId);
				Utilities.SetXmlNodeStringValue(playerCharacterIdNode, playerCharacterId);

				stateNode.Add (playerCharacterIdNode);
			}

			// TODO
			// Inventory page
			/*{
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
			
			// TODO
			/*// Inventory items
			foreach (string inventoryItemId in inventoryItemIds) {
				XElement inventoryItemNode = new XElement(Parameters.XmlTagInventoryItem);

				XElement inventoryItemIdNode = new XElement(Parameters.XmlTagId);
				Utilities.SetXmlNodeStringValue(inventoryItemIdNode, inventoryItemId);

				inventoryItemNode.Add(inventoryItemIdNode);
				stateNode.Add(inventoryItemNode);
			}*/
			
			// Characters
			foreach (KeyValuePair<string, CharacterState> entry in characterStates) {
				XElement characterNode = new XElement(Parameters.XmlTagCharacter);

				XElement idNode = new XElement(Parameters.XmlTagId);
				Utilities.SetXmlNodeStringValue(idNode, entry.Key);

				XElement characterStateNode = new XElement(Parameters.XmlTagCharacterState);
				Utilities.SetXmlNodeCharacterStateValue(characterStateNode, entry.Value);

				stateNode.Add(characterStateNode);
			}
			
			// Items
			foreach (KeyValuePair<string, ItemState> entry in itemStates) {
				XElement itemNode = new XElement(Parameters.XmlTagItem);

				XElement idNode = new XElement(Parameters.XmlTagId);
				Utilities.SetXmlNodeStringValue(idNode, entry.Key);
				
				XElement itemStateNode = new XElement(Parameters.XmlTagItemState);
				Utilities.SetXmlNodeItemStateValue(itemStateNode, entry.Value);

				stateNode.Add(itemStateNode);
			}
			
			// Initializes and returns the state file
			return new XDocument(stateNode);
		}
		
		private static void ProcessStateFile(XDocument stateFile) {
			currentRoomId = null;
			playerCharacterId = null;
			// TODO
			/*inventoryPage = 0;
			inventoryItemIds.Clear();*/
			hints.Clear();
			characterStates.Clear();
			itemStates.Clear();
			
			// State
			XElement stateNode = stateFile.Element(Parameters.XmlTagState);
			
			// Current room
			{
				XElement currentRoomIdNode = stateNode.Element(Parameters.XmlTagCurrentRoomId);
				currentRoomId = Utilities.GetXmlNodeStringValue(currentRoomIdNode);
			}

			// Player character ID
			{
				XElement playerCharacterIdNode = stateNode.Element(Parameters.XmlTagPlayerCharacterId);
				playerCharacterId = Utilities.GetXmlNodeStringValue(playerCharacterIdNode);
			}
			
			// TODO
			// Inventory page
			/*{
				XElement inventoryPageNode = stateNode.Element(Parameters.XmlTagInventoryPage);
				inventoryPage = Utilities.GetXmlNodeIntegerValue(inventoryPageNode);
			}*/
			
			// Hints
			foreach (XElement hintNode in stateNode.Elements(Parameters.XmlTagHint)) {
				string hint = Utilities.GetXmlNodeStringValue(hintNode);

				hints.Add(hint);
			}
			
			// TODO
			/*// Inventory items
			foreach (XElement inventoryItemNode in stateNode.Elements(Parameters.XmlTagInventoryItem)) {
				XElement inventoryItemIdNode = inventoryItemNode.Element(Parameters.XmlTagId);
				string inventoryItemId = Utilities.GetXmlNodeStringValue(inventoryItemIdNode);

				inventoryItemIds.Add(inventoryItemId);
			}*/
			
			// Characters
			foreach (XElement characterNode in stateNode.Elements(Parameters.XmlTagCharacter)) {
				XElement idNode = characterNode.Element(Parameters.XmlTagId);
				string id = Utilities.GetXmlNodeStringValue(idNode);
				XElement characterStateNode = characterNode.Element(Parameters.XmlTagCharacterState);
				CharacterState characterState = Utilities.GetXmlNodeCharacterStateValue(characterStateNode);

				characterStates.Add(id, characterState);
			}
			
			// Items
			foreach (XElement itemNode in stateNode.Elements(Parameters.XmlTagItem)) {
				XElement idNode = itemNode.Element(Parameters.XmlTagId);
				string id = Utilities.GetXmlNodeStringValue(idNode);
				XElement itemStateNode = itemNode.Element(Parameters.XmlTagItemState);
				ItemState itemState = Utilities.GetXmlNodeItemStateValue(itemStateNode);

				itemStates.Add(id, itemState);
			}
		}

	}
	
}
