using UnityEngine;

namespace FrameworkNamespace {

	public partial class GameCamera : MonoBehaviour {

		private Transform target;

		public void Awake() {
			instance = this;

			camera.orthographicSize = UtilityManager.GetCameraOrthographicSizeUnits();
		}
		
		public void LateUpdate() {
			if (target != null)
				transform.position = UtilityManager.GetPosition(target.position, transform.position.z);
		}
		
	}

}
