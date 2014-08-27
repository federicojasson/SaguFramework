using SaguFramework.Entities;
using SaguFramework.Structures.Serializable;
using System.Collections.Generic;
using UnityEngine;

namespace SaguFramework.Managers {

	public static class CreationManager {

		public static void CreateCharacter(CharacterParameters characterParameters, Vector2 positionInGame, float scaleFactor) {
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

		public static void CreateItem(ItemParameters itemParameters, Vector2 positionInGame, float scaleFactor) {
			GameObject item = new GameObject();
			item.AddComponent<Item>().SetBehaviour(itemParameters.Behaviour);
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
		
		public static void CreateMainMenu(MainMenuParameters mainMenuParameters) {
			// TODO
		}

		public static void CreateMenu(MenuParameters menuParameters) {
			// TODO
		}
		
		public static void CreateRoom(RoomParameters roomParameters) {
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
		
		public static void CreateSplashScreen(SplashScreenParameters splashScreenParameters) {
			// TODO
		}

	}

}
