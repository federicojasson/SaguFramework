using UnityEngine;

namespace SaguFramework {
	
	public class InventoryItem : MonoBehaviour {
		
		private string id;
		
		public void Awake() {
			Objects.RegisterInventoryItem(this);
			Hide();
		}
		
		public string GetId() {
			return id;
		}
		
		public void Hide() {
			gameObject.SetActive(false);
		}
		
		public void OnDestroy() {
			Objects.UnregisterInventoryItem(this);
		}
		
		public void SetId(string id) {
			this.id = id;
		}
		
		public void SetPosition(Vector2 position) {
			transform.position = Utilities.GetPosition(position, transform.position.z);
		}
		
		public void Show() {
			gameObject.SetActive(true);
		}
		
		private InventoryItemBehaviour GetBehaviour() {
			return GetComponentInChildren<InventoryItemBehaviour>();
		}
		
	}
	
}
