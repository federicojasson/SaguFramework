using UnityEngine;

public partial class GameAssets : MonoBehaviour {
	
	private static GameAssets instance; // Singleton instance

	public static Character CreateCharacter(string id, Vector2 position) {
		// Gets the character prefab
		Character characterPrefab = instance.CharacterPrefabs[id];
		
		// Instantiates the character prefab
		Character character = UtilityManager.Instantiate<Character>(characterPrefab, position);
		
		// Creates a game object that shows the background
		GameObject background = new GameObject("Background"); // TODO: use Parameters?
		background.transform.parent = character.transform;
		SpriteRenderer backgroundSpriteRenderer = background.AddComponent<SpriteRenderer>();
		backgroundSpriteRenderer.sortingLayerName = Parameters.CharacterBackgroundSortingLayer;
		backgroundSpriteRenderer.sortingOrder = 0; // TODO: use Parameters?
		backgroundSpriteRenderer.sprite = character.Image.Sprite;

		// TODO: set opacity
		
		return character;
	}

	public static Item CreateItem(string id, Vector2 position) {
		// Gets the item prefab
		Item itemPrefab = instance.ItemPrefabs[id];

		// Instantiates the item prefab
		Item item = UtilityManager.Instantiate<Item>(itemPrefab, position);

		// Creates a game object that shows the background
		GameObject background = new GameObject("Background"); // TODO: use Parameters?
		background.transform.parent = item.transform;
		SpriteRenderer backgroundSpriteRenderer = background.AddComponent<SpriteRenderer>();
		backgroundSpriteRenderer.sortingLayerName = Parameters.ItemBackgroundSortingLayer;
		backgroundSpriteRenderer.sortingOrder = 0; // TODO: use Parameters?
		backgroundSpriteRenderer.sprite = item.Image.Sprite;

		// TODO: set opacity

		return item;
	}

	public static Room CreateRoom(string id) {
		// Gets the room prefab
		Room roomPrefab = instance.RoomPrefabs[id];
		
		// Instantiates the room prefab
		Room room = UtilityManager.Instantiate<Room>(roomPrefab);
		
		// Creates a game object that shows the background
		GameObject background = new GameObject("Background"); // TODO: use Parameters?
		background.transform.parent = room.transform;
		SpriteRenderer backgroundSpriteRenderer = background.AddComponent<SpriteRenderer>();
		backgroundSpriteRenderer.sortingLayerName = Parameters.RoomBackgroundSortingLayer;
		backgroundSpriteRenderer.sortingOrder = 0; // TODO: use Parameters?
		backgroundSpriteRenderer.sprite = room.BackgroundImage.Sprite;

		// TODO: set opacity

		// Creates a game object that shows the foreground
		GameObject foreground = new GameObject("Foreground"); // TODO: use Parameters?
		foreground.transform.parent = room.transform;
		SpriteRenderer foregroundSpriteRenderer = foreground.AddComponent<SpriteRenderer>();
		foregroundSpriteRenderer.sortingLayerName = Parameters.RoomForegroundSortingLayer;
		foregroundSpriteRenderer.sortingOrder = 0; // TODO: use Parameters?
		foregroundSpriteRenderer.sprite = room.ForegroundImage.Sprite;

		// TODO: set opacity

		return room;
	}

}
