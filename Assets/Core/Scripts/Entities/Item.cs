using UnityEngine;

namespace SaguFramework {
	
	public class Item : MonoBehaviour {

		private string id;
		
		public void Awake() {
			Objects.RegisterItem(this);
		}

		public string GetId() {
			return id;
		}
		
		public void OnDestroy() {
			Objects.UnregisterItem(this);
		}

		public void SetId(string id) {
			this.id = id;
		}

		public void SetPosition(Vector2 position) {
			transform.position = Utilities.GetPosition(position, transform.position.z);
		}

		private ItemBehaviour GetBehaviour() {
			return GetComponentInChildren<ItemBehaviour>();
		}

	}
	
}
