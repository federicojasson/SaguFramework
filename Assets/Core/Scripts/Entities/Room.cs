using UnityEngine;

namespace SaguFramework {
	
	public class Room : MonoBehaviour {
		
		public void SetPosition(Vector2 position) {
			transform.position = Utilities.GetPosition(position, transform.position.z);
		}

	}
	
}
