using UnityEngine;

namespace SaguFramework {
	
	public class InventoryItem : MonoBehaviour {
		
		private string id;
		
		public void Awake() {
			Objects.RegisterInventoryItem(this);
		}
		
		public string GetId() {
			return id;
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
		
		private InventoryItemBehaviour GetBehaviour() {
			return GetComponentInChildren<InventoryItemBehaviour>();
		}
		
	}
	
}
