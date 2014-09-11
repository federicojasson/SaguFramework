using System.Collections;
using System.Collections.Generic;

namespace SaguFramework {
	
	public class RoomLoader : Loader {

		private static void CreateCharacters() {
			string currentRoomId = State.GetCurrentRoomId();
			RoomParameters roomParameters = Parameters.GetRoomParameters(currentRoomId);

			List<string> characterIds = State.GetRoomCharacterIds(currentRoomId);
			foreach (string characterId in characterIds) {
				CharacterState characterState = State.GetCharacterState(characterId);
				CharacterParameters characterParameters = Parameters.GetCharacterParameters(characterId);
				Factory.CreateCharacter(characterId, characterState, characterParameters, roomParameters);
			}
		}

		private static void CreateEntities() {
			CreateInventory();
			CreateInventoryItems();
			CreateRoom();
			CreateCharacters();
			CreateItems();
		}

		private static void CreateInventory() {
			InventoryParameters inventoryParameters = Parameters.GetInventoryParameters();
			Factory.CreateInventory(inventoryParameters);
		}

		private static void CreateInventoryItems() {
			InventoryParameters inventoryParameters = Parameters.GetInventoryParameters();

			List<string> inventoryItemIds = State.GetInventoryItemIds();
			foreach (string inventoryItemId in inventoryItemIds) {
				InventoryItemParameters inventoryItemParameters = Parameters.GetInventoryItemParameters(inventoryItemId);
				Factory.CreateInventoryItem(inventoryItemId, inventoryItemParameters, inventoryParameters);
			}
		}

		private static void CreateItems() {
			string currentRoomId = State.GetCurrentRoomId();
			RoomParameters roomParameters = Parameters.GetRoomParameters(currentRoomId);
			
			List<string> itemIds = State.GetRoomItemIds(currentRoomId);
			foreach (string itemId in itemIds) {
				ItemState itemState = State.GetItemState(itemId);
				ItemParameters itemParameters = Parameters.GetItemParameters(itemId);
				Factory.CreateItem(itemId, itemState, itemParameters, roomParameters);
			}
		}

		private static void CreateRoom() {
			string currentRoomId = State.GetCurrentRoomId();
			RoomParameters roomParameters = Parameters.GetRoomParameters(currentRoomId);
			Factory.CreateRoom(roomParameters);
		}
		
		protected override IEnumerator LoadSceneCoroutine() {
			CreateEntities();
			yield return StartCoroutine(GraphicHandler.FadeIn(Parameters.GetRoomLoaderParameters().FadeIn));
		}
		
		protected override IEnumerator UnloadSceneCoroutine() {
			yield return StartCoroutine(GraphicHandler.FadeOut(Parameters.GetRoomLoaderParameters().FadeOut));
		}

	}
	
}
