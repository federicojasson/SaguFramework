using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaguFramework {

	/// Loader of the room scene.
	/// Tasks:
	/// - Creates the room's entites.
	/// - Configures the camera.
	/// - Refreshes the game's input mode.
	public sealed class RoomLoader : Loader {

		/// Sets the player character as the camera's target.
		/// Also, sets the camera's boundaries according to the room's size.
		private static void ConfigureCamera() {
			// Gets the room's size
			Vector2 roomSize = Entities.GetRoom().GetSize();

			// Calculates the boundaries
			float width = roomSize.x;
			float height = roomSize.y;
			float x = Geometry.GameToWorldX(0f);
			float y = Geometry.GameToWorldY(0f);
			Rect boundaries = new Rect(x, y, width, height);

			// Sets the camera's boundaries
			CameraHandler.SetCameraBoundaries(boundaries);

			// Gets the player character
			string characterId = State.GetPlayerCharacter();
			Character character = Entities.GetCharacters()[characterId];

			// Sets the camera's target
			CameraHandler.SetCameraTarget(character);
		}

		/// Creates the room's characters.
		private static void CreateCharacters() {
			// Gets the current room's parameters
			string roomId = State.GetCurrentRoom();
			RoomParameters roomParameters = Parameters.GetRoomParameters(roomId);
			
			// Gets the current room's characters
			List<string> characterIds = State.GetRoomCharacters(roomId);

			foreach (string characterId in characterIds) {
				// Gets the character's state
				CharacterState characterState = State.GetCharacterState(characterId);

				// Gets the character's parameters
				CharacterParameters characterParameters = Parameters.GetCharacterParameters(characterId);

				// Creates the character
				Factory.CreateCharacter(characterId, characterState, characterParameters, roomParameters);
			}
		}

		/// Creates the scene's entities: inventory, inventory items, room, characters and items.
		private static void CreateEntities() {
			CreateInventory();
			CreateInventoryItems();
			CreateRoom();
			CreateCharacters();
			CreateItems();
		}

		/// Creates the inventory.
		private static void CreateInventory() {
			// Gets the inventory's parameters
			InventoryParameters inventoryParameters = Parameters.GetInventoryParameters();

			// Creates the inventory
			Factory.CreateInventory(inventoryParameters);
		}

		/// Creates the inventory items.
		private static void CreateInventoryItems() {
			// Gets the inventory's parameters
			InventoryParameters inventoryParameters = Parameters.GetInventoryParameters();

			// Gets the inventory items
			List<string> inventoryItemIds = State.GetInventoryItems();

			foreach (string inventoryItemId in inventoryItemIds) {
				// Gets the inventory item's parameters
				InventoryItemParameters inventoryItemParameters = Parameters.GetInventoryItemParameters(inventoryItemId);

				// Creates the inventory item
				Factory.CreateInventoryItem(inventoryItemId, inventoryItemParameters, inventoryParameters);
			}
		}

		/// Creates the room's items.
		private static void CreateItems() {
			// Gets the current room's parameters
			string roomId = State.GetCurrentRoom();
			RoomParameters roomParameters = Parameters.GetRoomParameters(roomId);

			// Gets the current room's items
			List<string> itemIds = State.GetRoomItems(roomId);

			foreach (string itemId in itemIds) {
				// Gets the item's state
				ItemState itemState = State.GetItemState(itemId);

				// Gets the item's parameters
				ItemParameters itemParameters = Parameters.GetItemParameters(itemId);

				// Creates the item
				Factory.CreateItem(itemId, itemState, itemParameters, roomParameters);
			}
		}

		/// Creates the room.
		private static void CreateRoom() {
			// Gets the current room's parameters
			string roomId = State.GetCurrentRoom();
			RoomParameters roomParameters = Parameters.GetRoomParameters(roomId);

			// Creates the room
			Factory.CreateRoom(roomParameters);
		}
		
		/// Performs the loading tasks.
		protected override IEnumerator LoadSceneCoroutine() {
			// Creates the room's entities
			CreateEntities();

			// Configures the camera
			ConfigureCamera();

			// Refreshes the input mode
			InputReader.RefreshInputMode();

			// Fades in
			yield return StartCoroutine(Drawer.FadeIn(Parameters.GetRoomLoaderParameters().FadeIn));
		}
		
		/// Performs the unloading tasks.
		protected override IEnumerator UnloadSceneCoroutine() {
			// Fades out
			yield return StartCoroutine(Drawer.FadeOut(Parameters.GetRoomLoaderParameters().FadeOut));
		}

	}
	
}
