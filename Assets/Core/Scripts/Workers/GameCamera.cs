using UnityEngine;

namespace SaguFramework {

	public partial class GameCamera : MonoBehaviour {

		private bool isActiveTarget;
		private Transform target;

		public void Awake() {
			// Sets itself as the singleton instance
			instance = this;

			// Sets the orthographic size
			camera.orthographicSize = UtilityManager.GetCameraOrthographicSizeUnits();
		}

		public void LateUpdate() {
			if (target != null) {
				// When the target is active, the camera is the one that moves
				// On the other hand, if the target is pasive, it gets moved in front of the camera
				if (isActiveTarget)
					transform.position = UtilityManager.GetPosition(target.position, transform.position.z);
				else
					target.position = UtilityManager.GetPosition(transform.position, target.position.z);
			}
		}

		public void SetTarget(Transform target, bool isActiveTarget) {
			this.isActiveTarget = isActiveTarget;
			this.target = target;
		}

	}

}
