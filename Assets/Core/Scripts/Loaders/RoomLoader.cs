using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaguFramework {
	
	public class RoomLoader : Loader {

		private static void ConfigureCamera() {
			Vector2 roomSize = Objects.GetRoom().GetSize();
			
			float width = roomSize.x;
			float height = roomSize.y;
			float x = Geometry.GameToWorldX(0f);
			float y = Geometry.GameToWorldY(0f) + height;
			Rect boundaries = new Rect(x, y, width, height);

			CameraHandler.SetCameraBoundaries(boundaries);

			string characterId = State.GetPlayerCharacter();
			Character character = Objects.GetCharacters()[characterId];
			CameraHandler.SetCameraTarget(character);
		}

		private static void CreateCharacters() {
			string roomId = State.GetCurrentRoom();
			RoomParameters roomParameters = Parameters.GetRoomParameters(roomId);

			List<string> characterIds = State.GetRoomCharacters(roomId);
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

			List<string> inventoryItemIds = State.GetInventoryItems();
			foreach (string inventoryItemId in inventoryItemIds) {
				InventoryItemParameters inventoryItemParameters = Parameters.GetInventoryItemParameters(inventoryItemId);
				Factory.CreateInventoryItem(inventoryItemId, inventoryItemParameters, inventoryParameters);
			}
		}

		private static void CreateItems() {
			string roomId = State.GetCurrentRoom();
			RoomParameters roomParameters = Parameters.GetRoomParameters(roomId);
			
			List<string> itemIds = State.GetRoomItems(roomId);
			foreach (string itemId in itemIds) {
				ItemState itemState = State.GetItemState(itemId);
				ItemParameters itemParameters = Parameters.GetItemParameters(itemId);
				Factory.CreateItem(itemId, itemState, itemParameters, roomParameters);
			}
		}

		private static void CreateRoom() {
			string roomId = State.GetCurrentRoom();
			RoomParameters roomParameters = Parameters.GetRoomParameters(roomId);
			Factory.CreateRoom(roomParameters);
		}
		
		protected override IEnumerator LoadSceneCoroutine() {
			CreateEntities();
			ConfigureCamera();
			GameHandler.UpdateGameMode();
			yield return StartCoroutine(GraphicHandler.FadeIn(Parameters.GetRoomLoaderParameters().FadeIn));
		}
		
		protected override IEnumerator UnloadSceneCoroutine() {
			yield return StartCoroutine(GraphicHandler.FadeOut(Parameters.GetRoomLoaderParameters().FadeOut));
		}

	}
	
}
