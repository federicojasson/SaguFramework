using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaguFramework {
	
	public class RoomLoader : Loader {
		
		protected override IEnumerator LoadSceneCoroutine() {
			float scaleFactor = GetScaleFactor();
			CreateInventory();
			CreateRoom();
			CreateCharacters(scaleFactor);
			CreateItems(scaleFactor);
			ConfigureCamera();

			yield return StartCoroutine(FadeInCoroutine(Parameters.GetRoomLoaderParameters().FadeIn));
		}
		
		protected override IEnumerator UnloadSceneCoroutine() {
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

		private void CreateCharacters(float scaleFactor) {
			string currentRoomId = State.GetCurrentRoomId();
			List<string> characterIds = State.GetRoomCharacterIds(currentRoomId);

			foreach (string characterId in characterIds) {
				CharacterParameters parameters = Parameters.GetCharacterParameters(characterId);
				Vector2 position = State.GetCharacterState(characterId).GetLocation().GetPosition();
				Character character = Factory.CreateCharacter(parameters, position, scaleFactor);
				character.SetId(characterId);
			}
		}

		private void CreateInventory() {
			InventoryParameters parameters = Parameters.GetInventoryParameters();
			Factory.CreateInventory(parameters);
		}

		private void CreateItems(float scaleFactor) {
			string currentRoomId = State.GetCurrentRoomId();
			List<string> itemIds = State.GetRoomItemIds(currentRoomId);

			foreach (string itemId in itemIds) {
				ItemParameters parameters = Parameters.GetItemParameters(itemId);
				Vector2 position = State.GetItemState(itemId).GetLocation().GetPosition();
				Item item = Factory.CreateItem(parameters, position, scaleFactor);
				item.SetId(itemId);
			}
		}

		private void CreateRoom() {
			string currentRoomId = State.GetCurrentRoomId();
			RoomParameters parameters = Parameters.GetRoomParameters(currentRoomId);
			Factory.CreateRoom(parameters);
		}

		private float GetScaleFactor() {
			string currentRoomId = State.GetCurrentRoomId();
			return Parameters.GetRoomParameters(currentRoomId).ScaleFactor;
		}

	}
	
}
