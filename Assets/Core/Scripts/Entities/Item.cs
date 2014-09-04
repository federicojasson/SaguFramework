using UnityEngine;

namespace SaguFramework {
	
	public class Item : MonoBehaviour {

		public void Awake() {
			Objects.RegisterItem(this);
		}

		public void OnDestroy() {
			Objects.UnregisterItem(this);
		}

		public void SetPosition(Vector2 position) {
			transform.position = Utilities.GetPosition(position, transform.position.z);
		}

		private ItemBehaviour GetBehaviour() {
			return GetComponentInChildren<ItemBehaviour>();
		}

	}
	
}
