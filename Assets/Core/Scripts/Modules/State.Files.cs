using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using UnityEngine;

namespace SaguFramework {

	// TODO: comentar

	public static partial class State {

		public static void Delete(string stateId) {
			try {
				string path = Parameters.GetStateFilePath(stateId);
				Utilities.DeleteFile(path);
			} catch (Exception) {}
		}

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
			XElement stateNode = new XElement(Parameters.XmlNodeState);
			
			// Current room
			{
				XElement currentRoomNode = new XElement(Parameters.XmlNodeCurrentRoom);
				Utilities.SetXmlNodeStringValue(currentRoomNode, currentRoom);
				
				stateNode.Add(currentRoomNode);
			}

			// Player character
			{
				XElement playerCharacterNode = new XElement(Parameters.XmlNodePlayerCharacter);
				Utilities.SetXmlNodeStringValue(playerCharacterNode, playerCharacter);

				stateNode.Add(playerCharacterNode);
			}
			
			// Hints
			foreach (string hint in hints) {
				XElement hintNode = new XElement(Parameters.XmlNodeHint);
				Utilities.SetXmlNodeStringValue(hintNode, hint);
				
				stateNode.Add(hintNode);
			}
			
			// Inventory items
			foreach (string inventoryItem in inventoryItems) {
				XElement inventoryItemNode = new XElement(Parameters.XmlNodeInventoryItem);
				Utilities.SetXmlNodeStringValue(inventoryItemNode, inventoryItem);

				stateNode.Add(inventoryItemNode);
			}
			
			// Characters
			foreach (KeyValuePair<string, CharacterState> entry in characters) {
				XAttribute idAttribute = new XAttribute(Parameters.XmlAttributeId, string.Empty);
				XElement directionNode = new XElement(Parameters.XmlNodeDirection);
				XElement roomNode = new XElement(Parameters.XmlNodeRoom);
				XElement xNode = new XElement(Parameters.XmlNodeX);
				XElement yNode = new XElement(Parameters.XmlNodeY);
				XElement positionNode = new XElement(Parameters.XmlNodePosition);
				XElement locationNode = new XElement(Parameters.XmlNodeLocation);
				XElement characterNode = new XElement(Parameters.XmlNodeCharacter);
				
				string id = entry.Key;
				CharacterState characterState = entry.Value;
				string direction = characterState.GetDirection().ToString();
				Location location = characterState.GetLocation();
				string room = location.GetRoom();
				Vector2 position = location.GetPosition();
				float x = position.x;
				float y = position.y;
				
				Utilities.SetXmlAttributeStringValue(idAttribute, id);
				Utilities.SetXmlNodeStringValue(directionNode, direction);
				Utilities.SetXmlNodeStringValue(roomNode, room);
				Utilities.SetXmlNodeFloatValue(xNode, x);
				Utilities.SetXmlNodeFloatValue(yNode, y);
				
				positionNode.Add(xNode);
				positionNode.Add(yNode);
				locationNode.Add(roomNode);
				locationNode.Add(positionNode);
				characterNode.Add(idAttribute);
				characterNode.Add(directionNode);
				characterNode.Add(locationNode);
				stateNode.Add(characterNode);
			}
			
			// Items
			foreach (KeyValuePair<string, ItemState> entry in items) {
				XAttribute idAttribute = new XAttribute(Parameters.XmlAttributeId, string.Empty);
				XElement roomNode = new XElement(Parameters.XmlNodeRoom);
				XElement xNode = new XElement(Parameters.XmlNodeX);
				XElement yNode = new XElement(Parameters.XmlNodeY);
				XElement positionNode = new XElement(Parameters.XmlNodePosition);
				XElement locationNode = new XElement(Parameters.XmlNodeLocation);
				XElement itemNode = new XElement(Parameters.XmlNodeItem);

				string id = entry.Key;
				ItemState itemState = entry.Value;
				Location location = itemState.GetLocation();
				string room = location.GetRoom();
				Vector2 position = location.GetPosition();
				float x = position.x;
				float y = position.y;

				Utilities.SetXmlAttributeStringValue(idAttribute, id);
				Utilities.SetXmlNodeStringValue(roomNode, room);
				Utilities.SetXmlNodeFloatValue(xNode, x);
				Utilities.SetXmlNodeFloatValue(yNode, y);

				positionNode.Add(xNode);
				positionNode.Add(yNode);
				locationNode.Add(roomNode);
				locationNode.Add(positionNode);
				itemNode.Add(idAttribute);
				itemNode.Add(locationNode);
				stateNode.Add(itemNode);
			}

			return new XDocument(stateNode);
		}
		
		private static void ProcessStateFile(XDocument stateFile) {
			characters.Clear();
			currentRoom = null;
			hints.Clear();
			inventoryItems.Clear();
			items.Clear();
			playerCharacter = null;
			
			// State
			XElement stateNode = stateFile.Element(Parameters.XmlNodeState);
			
			// Current room
			{
				XElement currentRoomNode = stateNode.Element(Parameters.XmlNodeCurrentRoom);
				currentRoom = Utilities.GetXmlNodeStringValue(currentRoomNode);
			}

			// Player character
			{
				XElement playerCharacterNode = stateNode.Element(Parameters.XmlNodePlayerCharacter);
				playerCharacter = Utilities.GetXmlNodeStringValue(playerCharacterNode);
			}
			
			// Hints
			foreach (XElement hintNode in stateNode.Elements(Parameters.XmlNodeHint)) {
				string hint = Utilities.GetXmlNodeStringValue(hintNode);
				hints.Add(hint);
			}
			
			// Inventory items
			foreach (XElement inventoryItemNode in stateNode.Elements(Parameters.XmlNodeInventoryItem)) {
				string inventoryItem = Utilities.GetXmlNodeStringValue(inventoryItemNode);
				inventoryItems.Add(inventoryItem);
			}
			
			// Characters
			foreach (XElement characterNode in stateNode.Elements(Parameters.XmlNodeCharacter)) {
				XAttribute idAttribute = characterNode.Attribute(Parameters.XmlAttributeId);
				XElement directionNode = characterNode.Element(Parameters.XmlNodeDirection);
				XElement locationNode = characterNode.Element(Parameters.XmlNodeLocation);
				XElement roomNode = locationNode.Element(Parameters.XmlNodeRoom);
				XElement positionNode = locationNode.Element(Parameters.XmlNodePosition);
				XElement xNode = positionNode.Element(Parameters.XmlNodeX);
				XElement yNode = positionNode.Element(Parameters.XmlNodeY);

				string id = Utilities.GetXmlAttributeStringValue(idAttribute);
				Direction direction = Utilities.GetEnumValue<Direction>(Utilities.GetXmlNodeStringValue(directionNode));
				float x = Utilities.GetXmlNodeFloatValue(xNode);
				float y = Utilities.GetXmlNodeFloatValue(yNode);
				Vector2 position = new Vector2(x, y);
				string room = Utilities.GetXmlNodeStringValue(roomNode);
				Location location = new Location(position, room);
				CharacterState characterState = new CharacterState(direction, location);

				characters.Add(id, characterState);
			}
			
			// Items
			foreach (XElement itemNode in stateNode.Elements(Parameters.XmlNodeItem)) {
				XAttribute idAttribute = itemNode.Attribute(Parameters.XmlAttributeId);
				XElement locationNode = itemNode.Element(Parameters.XmlNodeLocation);
				XElement roomNode = locationNode.Element(Parameters.XmlNodeRoom);
				XElement positionNode = locationNode.Element(Parameters.XmlNodePosition);
				XElement xNode = positionNode.Element(Parameters.XmlNodeX);
				XElement yNode = positionNode.Element(Parameters.XmlNodeY);
				
				string id = Utilities.GetXmlAttributeStringValue(idAttribute);
				float x = Utilities.GetXmlNodeFloatValue(xNode);
				float y = Utilities.GetXmlNodeFloatValue(yNode);
				Vector2 position = new Vector2(x, y);
				string room = Utilities.GetXmlNodeStringValue(roomNode);
				Location location = new Location(position, room);
				ItemState itemState = new ItemState(location);
				
				items.Add(id, itemState);
			}
		}

	}
	
}
