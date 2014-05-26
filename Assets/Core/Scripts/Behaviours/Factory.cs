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

	public void Awake() {
		// Allows static references to this class
		Factory.instance = this;

		// Prevents the factory object from being destroyed when the scene changes
		DontDestroyOnLoad(this);
	}

	protected abstract GameObject GetCharacterModel(string id);

	protected abstract GameObject GetInventoryItemModel(string id);

	protected abstract GameObject GetItemModel(string id);
	
}
