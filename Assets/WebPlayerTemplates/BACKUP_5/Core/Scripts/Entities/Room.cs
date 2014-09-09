using UnityEngine;

namespace SaguFramework {
	
	public class Room : MonoBehaviour {
		
		public void Awake() {
			Objects.RegisterRoom(this);
		}

		public Vector2 GetSize() {
			return GetImages()[0].GetSize();
		}
		
		public void OnDestroy() {
			Objects.UnregisterRoom();
		}
		
		public void SetPosition(Vector2 position) {
			transform.position = Utilities.GetPosition(position, transform.position.z);
		}

		private Image[] GetImages() {
			return GetComponentsInChildren<Image>();
		}

	}
	
}
