using UnityEngine;

//
// Factory - Behaviour class
//
// TODO: write class description
//
public abstract class Factory : MonoBehaviour {

	private static Factory instance; // Singleton

	public static GameObject CreateCharacter(Character character) {
		// Instantiates the game object
		string id = character.GetId();
		GameObject model = Factory.instance.GetCharacterModel(id);
		GameObject gameObject = (GameObject) Instantiate(model);
		
		// Sets the game object's properties
		gameObject.transform.position = new Vector2(character.GetX(), character.GetY());

		return gameObject;
	}

	public static GameObject CreateInventoryItem(InventoryItem inventoryItem) {
		// Instantiates the game object
		string id = inventoryItem.GetId();
		GameObject model = Factory.instance.GetInventoryItemModel(id);
		GameObject gameObject = (GameObject) Instantiate(model);

		return gameObject;
	}

	public static GameObject CreateItem(Item item) {
		// Instantiates the game object
		string id = item.GetId();
		GameObject model = Factory.instance.GetItemModel(id);
		GameObject gameObject = (GameObject) Instantiate(model);

		// Sets the game object's properties
		gameObject.transform.position = new Vector2(item.GetX(), item.GetY());

		return gameObject;
	}

	public static Texture2D GetCursorImageDisabledStatic() {
		return Factory.instance.GetCursorImageDisabled();
	}

	public static Texture2D GetCursorImageOrderLookStatic() {
		return Factory.instance.GetCursorImageOrderLook();
	}
	
	public static Texture2D GetCursorImageOrderTeleportStatic() {
		return Factory.instance.GetCursorImageOrderTeleport();
	}
	
	public static Texture2D GetCursorImageOrderWalkStatic() {
		return Factory.instance.GetCursorImageOrderWalk();
	}

	public static Texture2D GetCursorImagePauseStatic() {
		return Factory.instance.GetCursorImagePause();
	}

	public void Awake() {
		// Allows static references to this class
		Factory.instance = this;

		// Prevents the factory object from being destroyed when the scene changes
		DontDestroyOnLoad(this);
	}

	protected abstract GameObject GetCharacterModel(string id);

	protected abstract GameObject GetInventoryItemModel(string id);

	protected abstract GameObject GetItemModel(string id);

	protected abstract Texture2D GetCursorImageDisabled();
	
	protected abstract Texture2D GetCursorImageOrderLook();

	protected abstract Texture2D GetCursorImageOrderTeleport();

	protected abstract Texture2D GetCursorImageOrderWalk();

	protected abstract Texture2D GetCursorImagePause();
	
}
