using UnityEngine;

public class InventoryItem : MonoBehaviour {

	public Sprite Background;

	public void Awake() {
		// Hides the inventory item initially
		Hide();
	}

	public void Hide() {
		enabled = false;
	}

	public void Show() {
		enabled = true;
	}

}
