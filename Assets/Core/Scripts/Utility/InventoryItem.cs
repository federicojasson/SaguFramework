using UnityEngine;

//
// InventoryItem - Utility class
//
// This class represents an inventory item. Objects of this class are managed by the InventoryManager. A link with its
// game object is created when the latter is instantiated.
//
public class InventoryItem {
	
	private GameObject gameObject;
	private string id;

	public InventoryItem(string id) {
		this.id = id;
	}

	public GameObject GetGameObject() {
		return gameObject;
	}
	
	public string GetId() {
		return id;
	}
	
	public void SetGameObject(GameObject gameObject) {
		this.gameObject = gameObject;
	}

}
