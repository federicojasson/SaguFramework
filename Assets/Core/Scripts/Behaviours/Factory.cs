using UnityEngine;

public abstract class Factory : MonoBehaviour {

	private static Factory instance;

	public static GameObject CreateCharacter(Character character) {
		GameObject gameObject = (GameObject) Instantiate(Factory.instance.GetCharacterModel(character.GetId()));
		gameObject.transform.position = new Vector2(character.GetX(), character.GetY());

		return gameObject;
	}

	public static GameObject CreateInventoryItem(InventoryItem inventoryItem) {
		return (GameObject) Instantiate(Factory.instance.GetInventoryItemModel(inventoryItem.GetId()));
	}

	public static GameObject CreateItem(Item item) {
		GameObject gameObject = (GameObject) Instantiate(Factory.instance.GetItemModel(item.GetId()));
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
