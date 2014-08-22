using UnityEngine;

public partial class GameAssets : MonoBehaviour {
	
	private static GameAssets instance; // Singleton instance

	public static Character CreateCharacter(string id, Vector2 position) {
		// Gets the character prefab
		Character characterPrefab = instance.CharacterPrefabs[id];
		
		// Instantiates the character prefab
		Character character = UtilityManager.Instantiate<Character>(characterPrefab, position);
		
		// Creates a game object that shows the image
		//UtilityManager.CreateImageObject(character.transform, character.Image, Parameters.CharacterImageSortingLayer);
		
		return character;
	}

	public static Item CreateItem(string id, Vector2 position) {
		// Gets the item prefab
		Item itemPrefab = instance.ItemPrefabs[id];

		// Instantiates the item prefab
		Item item = UtilityManager.Instantiate<Item>(itemPrefab, position);

		// Creates a game object that shows the image
		//UtilityManager.CreateImageObject(item.transform, item.Image, Parameters.ItemImageSortingLayer);

		return item;
	}

	public static Room CreateRoom(string id) {
		// Gets the room prefab
		Room roomPrefab = instance.RoomPrefabs[id];
		
		// Instantiates the room prefab
		Room room = UtilityManager.Instantiate<Room>(roomPrefab);
		
		// Creates a game object that shows the background image
		//UtilityManager.CreateImageObject(room.transform, room.BackgroundImage, Parameters.RoomBackgroundImageSortingLayer);

		// Creates a game object that shows the foreground image
		//UtilityManager.CreateImageObject(room.transform, room.ForegroundImage, Parameters.RoomForegroundImageSortingLayer);

		return room;
	}

}
