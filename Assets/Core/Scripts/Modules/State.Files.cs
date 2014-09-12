using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace SaguFramework {
	
	public static partial class State {

		public static string[] GetStateIds() {
			try {
				FileInfo[] stateFiles = Utilities.GetDirectoryFiles(Parameters.StateFileExtension, Parameters.GetStateFilesDirectoryPath());
				FileInfo[] orderedStateFiles = Utilities.OrderFilesByLastWriteTimeDescending(stateFiles);
				
				string[] stateIds = new string[orderedStateFiles.Length];
				for (int i = 0; i < orderedStateFiles.Length; i++)
					stateIds[i] = Utilities.GetFileNameWithoutExtension(orderedStateFiles[i]);
				
				return stateIds;
			} catch (Exception) {
				// There was a problem reading or processing the state files directory
				return new string[0];
			}
		}

		public static void Load(string stateId) {
			// TODO: errors, exceptions?
			
			string path = Parameters.GetStateFilePath(stateId);
			XDocument file = Utilities.ReadXmlFile(path);
			ProcessStateFile(file);
		}

		public static void LoadInitial() {
			string resourcePath = Parameters.InitialStateFileResourcePath;
			XDocument file = Utilities.ReadResourceXmlFile(resourcePath);
			ProcessStateFile(file);
		}

		public static void Save(string stateId) {
			XDocument file = GenerateStateFile();
			string path = Parameters.GetStateFilePath(stateId);
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

			// Player character
			{
				XElement playerCharacterIdNode = new XElement(Parameters.XmlTagPlayerCharacterId);
				Utilities.SetXmlNodeStringValue(playerCharacterIdNode, playerCharacterId);

				stateNode.Add(playerCharacterIdNode);
			}
			
			// Hints
			foreach (string hint in hints) {
				XElement hintNode = new XElement(Parameters.XmlTagHint);
				Utilities.SetXmlNodeStringValue(hintNode, hint);
				
				stateNode.Add(hintNode);
			}
			
			// Inventory items
			foreach (string inventoryItemId in inventoryItemIds) {
				XElement inventoryItemNode = new XElement(Parameters.XmlTagInventoryItem);
				
				XElement idNode = new XElement(Parameters.XmlTagId);
				Utilities.SetXmlNodeStringValue(idNode, inventoryItemId);
				
				inventoryItemNode.Add(idNode);
				stateNode.Add(inventoryItemNode);
			}
			
			// Characters
			foreach (KeyValuePair<string, CharacterState> entry in characterStates) {
				XElement characterNode = new XElement(Parameters.XmlTagCharacter);
				
				XElement idNode = new XElement(Parameters.XmlTagId);
				Utilities.SetXmlNodeStringValue(idNode, entry.Key);
				
				XElement characterStateNode = new XElement(Parameters.XmlTagCharacterState);
				Utilities.SetXmlNodeCharacterStateValue(characterStateNode, entry.Value);
				
				characterNode.Add(idNode);
				characterNode.Add(characterStateNode);
				stateNode.Add(characterNode);
			}
			
			// Items
			foreach (KeyValuePair<string, ItemState> entry in itemStates) {
				XElement itemNode = new XElement(Parameters.XmlTagItem);
				
				XElement idNode = new XElement(Parameters.XmlTagId);
				Utilities.SetXmlNodeStringValue(idNode, entry.Key);
				
				XElement itemStateNode = new XElement(Parameters.XmlTagItemState);
				Utilities.SetXmlNodeItemStateValue(itemStateNode, entry.Value);
				
				itemNode.Add(idNode);
				itemNode.Add(itemStateNode);
				stateNode.Add(itemNode);
			}

			return new XDocument(stateNode);
		}
		
		private static void ProcessStateFile(XDocument stateFile) {
			characterStates.Clear();
			currentRoomId = null;
			hints.Clear();
			inventoryItemIds.Clear();
			itemStates.Clear();
			playerCharacterId = null;
			
			// State
			XElement stateNode = stateFile.Element(Parameters.XmlTagState);
			
			// Current room
			{
				XElement currentRoomIdNode = stateNode.Element(Parameters.XmlTagCurrentRoomId);
				currentRoomId = Utilities.GetXmlNodeStringValue(currentRoomIdNode);
			}

			// Player character
			{
				XElement playerCharacterIdNode = stateNode.Element(Parameters.XmlTagPlayerCharacterId);
				playerCharacterId = Utilities.GetXmlNodeStringValue(playerCharacterIdNode);
			}
			
			// Hints
			foreach (XElement hintNode in stateNode.Elements(Parameters.XmlTagHint)) {
				string hint = Utilities.GetXmlNodeStringValue(hintNode);
				
				hints.Add(hint);
			}
			
			// Inventory items
			foreach (XElement inventoryItemNode in stateNode.Elements(Parameters.XmlTagInventoryItem)) {
				XElement idNode = inventoryItemNode.Element(Parameters.XmlTagId);
				string id = Utilities.GetXmlNodeStringValue(idNode);
				
				inventoryItemIds.Add(id);
			}
			
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
