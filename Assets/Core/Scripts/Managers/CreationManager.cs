using SaguFramework.Entities;
using SaguFramework.Structures.Serializable;
using System.Collections.Generic;
using UnityEngine;

namespace SaguFramework.Managers {

	public static class CreationManager {

		public static void CreateCurrentRoom() {
			// Gets the current room ID
			string currentRoomId = StateManager.GetCurrentRoomId();

			// Gets the IDs of the characters and items located in the room
			List<string> characterIds = StateManager.GetRoomCharacterIds(currentRoomId);
			List<string> itemIds = StateManager.GetRoomItemIds(currentRoomId);

			// Creates the room
			RoomParameters roomParameters = AssetManager.GetRoomParameters(currentRoomId);
			CreateRoom(roomParameters);

			// Creates the characters
			foreach (string characterId in characterIds) {
				Vector2 positionInGame = StateManager.GetCharacterLocation(characterId).GetPositionInGame();
				CharacterParameters characterParameters = AssetManager.GetCharacterParameters(characterId);
				CreateCharacter(characterParameters, positionInGame, roomParameters.ScaleFactor);
			}

			// Creates the items
			foreach (string itemId in itemIds) {
				Vector2 positionInGame = StateManager.GetItemLocation(itemId).GetPositionInGame();
				ItemParameters itemParameters = AssetManager.GetItemParameters(itemId);
				CreateItem(itemParameters, positionInGame, roomParameters.ScaleFactor);
			}
		}

		public static void CreateMainMenu() {
			// Gets the main menu's parameters
			MenuParameters mainMenuParameters = AssetManager.GetMainMenuParameters();
			
			// Creates the main menu
			CreateMenu(mainMenuParameters);
		}

		public static void CreateMainSplashScreen() {
			// Gets the main splash screen's parameters
			SplashScreenParameters mainSplashScreenParameters = AssetManager.GetMainSplashScreenParameters();

			// Creates the main splash screen
			CreateSplashScreen(mainSplashScreenParameters);
		}

		public static void CreateMenu(string menuId) {
			// Gets the menu's parameters
			MenuParameters menuParameters = AssetManager.GetMenuParameters(menuId);

			// Creates the menu
			CreateMenu(menuParameters);
		}

		public static void CreateSplashScreen() {
			// Gets the splash screens' parameters
			SplashScreenParameters[] splashScreensParameters = AssetManager.GetSplashScreensParameters();

			// Selects a random splash screen
			int randomIndex = Random.Range(0, splashScreensParameters.Length);
			SplashScreenParameters splashScreenParameters = splashScreensParameters[randomIndex];

			// Creates the splash screen
			CreateSplashScreen(splashScreenParameters);
		}

		private static void CreateCharacter(CharacterParameters characterParameters, Vector2 positionInGame, float scaleFactor) {
			GameObject character = new GameObject();
			character.AddComponent<Character>();
			character.transform.position = UtilityManager.GameToWorldPosition(positionInGame);

			GameObject characterImage = new GameObject();
			Image image = character.AddComponent<Image>();
			characterImage.transform.parent = character.transform;
			characterImage.transform.localPosition = Vector3.zero;

			// TODO
			/*// Gets the character prefab
			Character characterPrefab = instance.CharacterPrefabs[id];
			
			// Instantiates the character prefab
			Character character = UtilityManager.Instantiate<Character>(characterPrefab);
			
			// Creates a game image to show the character
			GameImage characterImage = UtilityManager.CreateGameImage();
			characterImage.transform.parent = character.transform;
			characterImage.SetParameters(character.ImageParameters);
			characterImage.SetRelativeSize(scaleFactor * characterImage.GetRelativeSize());
			
			// Sets the position in the world
			character.transform.position = UtilityManager.GameToWorldPosition(positionInGame);
			
			return character;*/
		}

		private static void CreateItem(ItemParameters itemParameters, Vector2 positionInGame, float scaleFactor) {
			GameObject item = new GameObject();
			item.AddComponent<Item>();
			item.transform.position = UtilityManager.GameToWorldPosition(positionInGame);
			
			GameObject itemImage = new GameObject();
			itemImage.transform.parent = item.transform;
			itemImage.transform.localPosition = Vector3.zero;

			// TODO
			/*// Gets the item prefab
			Item itemPrefab = instance.ItemPrefabs[id];
			
			// Instantiates the item prefab
			Item item = UtilityManager.Instantiate<Item>(itemPrefab);
			
			// Creates a game image to show the item
			GameImage itemImage = UtilityManager.CreateGameImage();
			itemImage.transform.parent = item.transform;
			itemImage.SetParameters(item.ImageParameters);
			itemImage.SetRelativeSize(scaleFactor * itemImage.GetRelativeSize());
			
			// Sets the position in the world
			item.transform.position = UtilityManager.GameToWorldPosition(positionInGame);
			
			return item;*/
		}

		private static void CreateMenu(MenuParameters menuParameters) {
			// TODO
		}
		
		private static void CreateRoom(RoomParameters roomParameters) {
			// TODO
			/*// Gets the room prefab
			Room roomPrefab = instance.RoomPrefabs[id];
			
			// Instantiates the room prefab
			Room room = UtilityManager.Instantiate<Room>(roomPrefab);
			
			// Creates a game image to show the room's background
			GameImage roomBackgroundImage = UtilityManager.CreateGameImage();
			roomBackgroundImage.transform.parent = room.transform;
			roomBackgroundImage.SetParameters(room.BackgroundImageParameters);
			
			// Creates a game image to show the room's foreground
			GameImage roomForegroundImage = UtilityManager.CreateGameImage();
			roomForegroundImage.transform.parent = room.transform;
			roomForegroundImage.SetParameters(room.ForegroundImageParameters);
			
			// Sets the position in the world
			float roomHeightUnits = roomBackgroundImage.GetHeightUnits();
			float roomWidthUnits = roomBackgroundImage.GetWidthUnits();
			float gameHeightUnits = UtilityManager.GetGameHeightUnits();
			float gameWidthUnits = UtilityManager.GetGameWidthUnits();
			float xInGame = 0.5f * roomWidthUnits / gameWidthUnits;
			float yInGame = 0.5f * roomHeightUnits / gameHeightUnits;
			Vector2 positionInGame = new Vector2(xInGame, yInGame);
			room.transform.position = UtilityManager.GameToWorldPosition(positionInGame);
			
			return room;*/
		}

		private static void CreateSplashScreen(SplashScreenParameters splashScreenParameters) {
			// TODO
		}

	}

}
