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
				Character character = Factory.CreateCharacter(characterParameters, roomParameters);
				character.SetId(characterId);
				character.SetPosition(Geometry.GameToWorldPosition(characterState.GetLocation().GetPosition()));
				// TODO: direction
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
			Inventory inventory = Factory.CreateInventory(inventoryParameters);
			inventory.Hide();
		}

		private static void CreateInventoryItems() {
			List<string> inventoryItemIds = State.GetInventoryItemIds();
			foreach (string inventoryItemId in inventoryItemIds) {
				InventoryItemParameters inventoryItemParameters = Parameters.GetInventoryItemParameters(inventoryItemId);
				InventoryItem inventoryItem = Factory.CreateInventoryItem(inventoryItemParameters);
				inventoryItem.Hide();
				inventoryItem.SetId(inventoryItemId);
			}
		}

		private static void CreateItems() {
			string currentRoomId = State.GetCurrentRoomId();
			RoomParameters roomParameters = Parameters.GetRoomParameters(currentRoomId);
			
			List<string> itemIds = State.GetRoomItemIds(currentRoomId);
			foreach (string itemId in itemIds) {
				ItemState itemState = State.GetItemState(itemId);
				ItemParameters itemParameters = Parameters.GetItemParameters(itemId);
				Item item = Factory.CreateItem(itemParameters, roomParameters);
				item.SetId(itemId);
				item.SetPosition(Geometry.GameToWorldPosition(itemState.GetLocation().GetPosition()));
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
