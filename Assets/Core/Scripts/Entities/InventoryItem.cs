using UnityEngine;

public class InventoryItem : MonoBehaviour {

	public GameImage Image;

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
