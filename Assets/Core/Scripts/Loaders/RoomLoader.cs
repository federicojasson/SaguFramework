using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaguFramework {
	
	public class RoomLoader : Loader {
		
		protected override IEnumerator LoadSceneCoroutine() {
			Vector2 inventoryItemsSize = GetInventoryItemsSize();
			CreateInventory();
			CreateInventoryItems(inventoryItemsSize);
			float roomScaleFactor = GetRoomScaleFactor();
			CreateRoom();
			CreateCharacters(roomScaleFactor);
			CreateItems(roomScaleFactor);
			ConfigureCamera();
			InputHandler.GetInstance().SetInputMode(InputMode.Playing);
			yield return StartCoroutine(FadeInCoroutine(Parameters.GetRoomLoaderParameters().FadeIn));
		}
		
		protected override IEnumerator UnloadSceneCoroutine() {
			InputHandler.GetInstance().SetInputMode(InputMode.Disabled);
			yield return StartCoroutine(FadeOutCoroutine(Parameters.GetRoomLoaderParameters().FadeOut));
		}

		private void ConfigureCamera() {
			Vector2 size = Objects.GetRoom().GetSize();

			float x = Geometry.GameToWorldX(0f);
			float y = Geometry.GameToWorldY(0f) + size.y;
			float width = size.x;
			float height = size.y;
			Rect boundaries = new Rect(x, y, width, height);

			GameCamera camera = GameCamera.GetInstance();
			camera.SetBoundaries(boundaries);
			camera.SetTarget(Objects.GetPlayerCharacter().transform);
		}

		private void CreateCharacters(float roomScaleFactor) {
			string currentRoomId = State.GetCurrentRoomId();
			List<string> characterIds = State.GetRoomCharacterIds(currentRoomId);

			foreach (string characterId in characterIds) {
				CharacterParameters parameters = Parameters.GetCharacterParameters(characterId);
				Vector2 position = State.GetCharacterState(characterId).GetLocation().GetPosition();
				Character character = Factory.CreateCharacter(parameters, position, roomScaleFactor);
				character.SetId(characterId);
			}
		}

		private void CreateInventory() {
			InventoryParameters parameters = Parameters.GetInventoryParameters();
			Factory.CreateInventory(parameters);
		}

		private void CreateInventoryItems(Vector2 inventoryItemsSize) {
			List<string> inventoryItemIds = State.GetInventoryItemIds();

			foreach (string inventoryItemId in inventoryItemIds) {
				InventoryItemParameters parameters = Parameters.GetInventoryItemParameters(inventoryItemId);
				InventoryItem inventoryItem = Factory.CreateInventoryItem(parameters, inventoryItemsSize);
				inventoryItem.SetId(inventoryItemId);
			}
		}

		private void CreateItems(float roomScaleFactor) {
			string currentRoomId = State.GetCurrentRoomId();
			List<string> itemIds = State.GetRoomItemIds(currentRoomId);

			foreach (string itemId in itemIds) {
				ItemParameters parameters = Parameters.GetItemParameters(itemId);
				Vector2 position = State.GetItemState(itemId).GetLocation().GetPosition();
				Item item = Factory.CreateItem(parameters, position, roomScaleFactor);
				item.SetId(itemId);
			}
		}

		private void CreateRoom() {
			string currentRoomId = State.GetCurrentRoomId();
			RoomParameters parameters = Parameters.GetRoomParameters(currentRoomId);
			Factory.CreateRoom(parameters);
		}

		private Vector2 GetInventoryItemsSize() {
			return Parameters.GetInventoryParameters().InventoryItemsSize;
		}

		private float GetRoomScaleFactor() {
			string currentRoomId = State.GetCurrentRoomId();
			return Parameters.GetRoomParameters(currentRoomId).ScaleFactor;
		}

	}
	
}
