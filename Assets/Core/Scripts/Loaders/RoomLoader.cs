using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaguFramework {
	
	public class RoomLoader : Loader {

		private RoomParameters roomParameters;

		protected override IEnumerator LoadSceneCoroutine() {
			// Creates the room
			roomParameters = CreateRoom();

			// Creates the inventory
			InventoryParameters inventoryParameters = CreateInventory();

			// Creates the inventory items
			CreateInventoryItems(inventoryParameters);

			// Creates the characters
			CreateCharacters(roomParameters);

			// Creates the items
			CreateItems(roomParameters);

			// Fades in
			yield return StartCoroutine(Fader.GetInstance().FadeInCoroutine(roomParameters.FadingIn));
		}
		
		protected override IEnumerator UnloadSceneCoroutine() {
			// Fades out
			yield return StartCoroutine(Fader.GetInstance().FadeOutCoroutine(roomParameters.FadingOut));
		}

		private void CreateCharacters(RoomParameters roomParameters) {
			// Gets the current room's ID
			string currentRoomId = StateManager.GetCurrentRoomId();

			// Gets the IDs of the characters located in the room
			List<string> characterIds = StateManager.GetRoomCharacterIds(currentRoomId);

			// Creates the characters
			foreach (string characterId in characterIds) {
				// Gets the location of the character
				Vector2 positionInGame = StateManager.GetCharacterLocation(characterId).GetPositionInGame();

				// Gets the character's parameters
				CharacterParameters characterParameters = ParameterManager.GetCharacterParameters(characterId);

				// Creates the character
				CreationManager.CreateCharacter(characterParameters, positionInGame, roomParameters.ScaleFactor);
			}
		}

		private InventoryParameters CreateInventory() {
			// Gets the inventory's parameters
			InventoryParameters inventoryParameters = ParameterManager.GetInventoryParameters();

			// Creates the inventory
			CreationManager.CreateInventory(inventoryParameters);

			return inventoryParameters;
		}

		private void CreateInventoryItems(InventoryParameters inventoryParameters) {
			// Gets the IDs of the inventory items
			List<string> inventoryItemIds = StateManager.GetInventoryItemIds();

			// Creates the inventory items
			foreach (string inventoryItemId in inventoryItemIds) {
				// TODO: use inventoryParameters

				// Gets the inventory item's parameters
				InventoryItemParameters inventoryItemParameters = ParameterManager.GetInventoryItemParameters(inventoryItemId);

				// Creates the inventory item
				CreationManager.CreateInventoryItem(inventoryItemParameters);
			}
		}

		private void CreateItems(RoomParameters roomParameters) {
			// Gets the current room's ID
			string currentRoomId = StateManager.GetCurrentRoomId();
			
			// Gets the IDs of the items located in the room
			List<string> itemIds = StateManager.GetRoomItemIds(currentRoomId);
			
			// Creates the items
			foreach (string itemId in itemIds) {
				// Gets the location of the item
				Vector2 positionInGame = StateManager.GetItemLocation(itemId).GetPositionInGame();
				
				// Gets the item's parameters
				ItemParameters itemParameters = ParameterManager.GetItemParameters(itemId);
				
				// Creates the item
				CreationManager.CreateItem(itemParameters, positionInGame, roomParameters.ScaleFactor);
			}
		}

		private RoomParameters CreateRoom() {
			// Gets the current room's ID
			string currentRoomId = StateManager.GetCurrentRoomId();

			// Gets the room's parameters
			RoomParameters roomParameters = ParameterManager.GetRoomParameters(currentRoomId);

			// Creates the room
			CreationManager.CreateRoom(roomParameters);

			return roomParameters;
		}

	}
	
}
