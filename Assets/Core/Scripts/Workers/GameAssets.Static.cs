using UnityEngine;

public partial class GameAssets : MonoBehaviour {
	
	private static GameAssets instance; // Singleton instance

	public static Character CreateCharacter(string id, Vector2 gamePosition, float scaleFactor) {
		// Gets the character prefab
		Character characterPrefab = instance.CharacterPrefabs[id];

		// Instantiates the character prefab
		Character character = UtilityManager.Instantiate<Character>(characterPrefab);
		
		// Creates a game image to show the character
		GameImage characterImage = UtilityManager.CreateGameImage();
		characterImage.transform.parent = character.transform;
		characterImage.SetParameters(character.ImageParameters);
		characterImage.SetRelativeSize(scaleFactor * characterImage.GetRelativeSize());
		
		// Sets the world position
		Vector2 worldPosition = UtilityManager.GameToWorldPosition(gamePosition);
		character.transform.position = worldPosition;

		return character;
	}

	public static Item CreateItem(string id, Vector2 gamePosition, float scaleFactor) {
		// Gets the item prefab
		Item itemPrefab = instance.ItemPrefabs[id];

		// Instantiates the item prefab
		Item item = UtilityManager.Instantiate<Item>(itemPrefab);

		// Creates a game image to show the item
		GameImage itemImage = UtilityManager.CreateGameImage();
		itemImage.transform.parent = item.transform;
		itemImage.SetParameters(item.ImageParameters);
		itemImage.SetRelativeSize(scaleFactor * itemImage.GetRelativeSize());

		// Sets the world position
		Vector2 worldPosition = UtilityManager.GameToWorldPosition(gamePosition);
		item.transform.position = worldPosition;

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
		
		// Sets the world position
		// TODO: order this
		float x = 0.5f * Parameters.PixelsPerUnit * roomBackgroundImage.renderer.bounds.size.x / (UtilityManager.GetGameScreenWidthPixels());
		Vector2 gamePosition = new Vector2(x, 0.5f);
		Vector2 worldPosition = UtilityManager.GameToWorldPosition(gamePosition);
		room.transform.position = worldPosition;

		return room;
	}

}
