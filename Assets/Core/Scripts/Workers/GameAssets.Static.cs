using UnityEngine;

public partial class GameAssets : MonoBehaviour {
	
	private static GameAssets instance; // Singleton instance

	public static Character CreateCharacter(string id, Vector2 position, Room room) {
		// Gets the character prefab
		Character characterPrefab = instance.CharacterPrefabs[id];
		
		// Instantiates the character prefab
		Character character = UtilityManager.Instantiate<Character>(characterPrefab, position);
		
		// Creates a game image to show the character
		GameImage characterImage = UtilityManager.CreateGameImage();
		characterImage.transform.parent = character.transform;
		characterImage.SetParameters(character.ImageParameters);
		characterImage.SetRelativeSize(room.ScaleFactor * characterImage.GetRelativeSize());
		
		return character;
	}

	public static Item CreateItem(string id, Vector2 position, Room room) {
		// Gets the item prefab
		Item itemPrefab = instance.ItemPrefabs[id];

		// Instantiates the item prefab
		Item item = UtilityManager.Instantiate<Item>(itemPrefab, position);

		// Creates a game image to show the item
		GameImage itemImage = UtilityManager.CreateGameImage();
		itemImage.transform.parent = item.transform;
		itemImage.SetParameters(item.ImageParameters);
		itemImage.SetRelativeSize(room.ScaleFactor * itemImage.GetRelativeSize());

		return item;
	}

	public static Room CreateRoom(string id) {
		// Gets the room prefab
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

		return room;
	}

}
