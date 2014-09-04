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
			camera.backgroundColor = Parameters.GetCameraBackgroundColor();
			camera.orthographicSize = 0.5f * Geometry.GetScreenHeightInUnits();
		}

		public Vector2 GetPosition() {
			return transform.position;
		}

		public void LateUpdate() {
			if (target != null) {
				float halfGameWidthInUnits = 0.5f * Geometry.GetGameWidthInUnits();
				float minimumX = boundaries.x + halfGameWidthInUnits;
				float maximumX = minimumX + boundaries.width - halfGameWidthInUnits;
				float x = Mathf.Clamp(target.position.x, minimumX, maximumX);

				float halfGameHeightInUnits = 0.5f * Geometry.GetGameHeightInUnits();
				float minimumY = boundaries.y - boundaries.height + halfGameHeightInUnits;
				float maximumY = minimumY + boundaries.height - halfGameHeightInUnits;
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
