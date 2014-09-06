using UnityEngine;

namespace SaguFramework {
	
	public class Inventory : MonoBehaviour {
		
		public void Awake() {
			Objects.RegisterInventory(this);
			Hide();
		}
		
		public void Hide() {
			gameObject.SetActive(false);
		}
		
		public void OnDestroy() {
			Objects.UnregisterInventory();
		}
		
		public void OnEnable() {
			SetPosition(GameCamera.GetInstance().GetPosition());
		}
		
		public void Show() {
			gameObject.SetActive(true);
		}
		
		private void SetPosition(Vector2 position) {
			transform.position = Utilities.GetPosition(position, transform.position.z);
		}
		
	}
	
}
