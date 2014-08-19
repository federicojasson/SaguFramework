using UnityEngine;

public class InventoryItem : MonoBehaviour {

	public Sprite Background;

	public void Awake() {
		// Hides the inventory item
		enabled = false;
	}

}
