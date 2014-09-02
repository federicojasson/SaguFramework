using UnityEngine;

namespace SaguFramework {
	
	public class Inventory : MonoBehaviour {
		
		public void Awake() {
			// Registers itself with the ObjectManager
			ObjectManager.RegisterInventory(this);

			// Hides the inventory initially
			Hide();
		}
		
		public void Hide() {
			// Deactivates the object in order to make the inventory item invisible
			gameObject.SetActive(false);
		}
		
		public void OnDestroy() {
			// Unregisters itself from the ObjectManager
			ObjectManager.UnregisterInventory();
		}
		
		public void OnEnable() {
			// Moves the inventory in front of the camera
			GameCamera.GetInstance().MoveInFront(transform);
		}
		
		public void Show() {
			// Activates the object in order to make the menu visible
			gameObject.SetActive(true);
		}
		
	}
	
}
