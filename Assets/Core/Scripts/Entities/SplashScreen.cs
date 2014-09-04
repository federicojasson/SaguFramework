using UnityEngine;

namespace SaguFramework {
	
	public class SplashScreen : MonoBehaviour {

		public void OnEnable() {
			SetPosition(GameCamera.GetInstance().GetPosition());
		}

		private void SetPosition(Vector2 position) {
			transform.position = Utilities.GetPosition(position, transform.position.z);
		}

	}
	
}
