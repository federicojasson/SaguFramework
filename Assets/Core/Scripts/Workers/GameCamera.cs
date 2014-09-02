using UnityEngine;

namespace SaguFramework {
	
	public class GameCamera : Worker {

		private static GameCamera instance;

		public static GameCamera GetInstance() {
			return instance;
		}

		private Rect boundaries;
		private Transform target;
		
		public override void Awake() {
			base.Awake();
			instance = this;
		}

		public void LateUpdate() {
			camera.orthographicSize = Geometry.GetScreenHeightUnits() / 2f;

			if (target != null) {
				float halfGameWidthUnits = Geometry.GetGameWidthUnits() / 2f;
				float minimumX = boundaries.x + halfGameWidthUnits;
				float maximumX = minimumX + boundaries.width - halfGameWidthUnits;
				float x = Mathf.Clamp(target.position.x, minimumX, maximumX);

				float halfGameHeightUnits = Geometry.GetGameHeightUnits() / 2f;
				float minimumY = boundaries.y - boundaries.height + halfGameHeightUnits;
				float maximumY = minimumY + boundaries.height - halfGameHeightUnits;
				float y = Mathf.Clamp(target.position.y, minimumY, maximumY);

				transform.position = new Vector3(x, y, transform.position.z);
			}
		}

		public void SetBoundaries(Rect boundaries) {
			this.boundaries = boundaries;
		}

		public void SetTarget(Transform target) {
			this.target = target;
		}

	}
	
}
