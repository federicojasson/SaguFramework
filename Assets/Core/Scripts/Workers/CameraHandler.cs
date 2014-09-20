using UnityEngine;

namespace SaguFramework {
	
	public sealed class CameraHandler : Worker {

		private static Rect boundaries;
		private static CameraHandler instance;
		private static Entity target;

		public static Vector2 GetCameraPosition() {
			return instance.transform.position;
		}

		public static Vector2 ScreenToWorldPosition(Vector2 position) {
			return instance.camera.ScreenToWorldPoint(position);
		}

		public static void SetCameraBoundaries(Rect boundaries) {
			CameraHandler.boundaries = boundaries;
		}

		public static void SetCameraTarget(Entity target) {
			CameraHandler.target = target;
		}

		public override void Awake() {
			base.Awake();
			instance = this;
			gameObject.AddComponent<Camera>();
			transform.position = Utilities.GetVector3(transform.position, Parameters.DepthCamera);
			camera.backgroundColor = Parameters.GetCameraBackgroundColor();
			camera.farClipPlane = Mathf.Abs(transform.position.z);
			camera.isOrthoGraphic = true;
			camera.orthographicSize = 0.5f * Geometry.GetScreenHeightInUnits();
		}
		
		public void LateUpdate() {
			if (target != null) {
				Vector2 targetPosition = target.GetPosition();
				
				float gameWidthInUnits = Geometry.GetGameWidthInUnits();
				float minimumX = boundaries.x + 0.5f * gameWidthInUnits;
				float maximumX = boundaries.x + boundaries.width - 0.5f * gameWidthInUnits;
				float x = Mathf.Clamp(targetPosition.x, minimumX, maximumX);
				
				float gameHeightInUnits = Geometry.GetGameHeightInUnits();
				float minimumY = boundaries.y + 0.5f * gameHeightInUnits;
				float maximumY = boundaries.y + boundaries.height - 0.5f * gameHeightInUnits;
				float y = Mathf.Clamp(targetPosition.y, minimumY, maximumY);
				
				transform.position = new Vector3(x, y, transform.position.z);
			}
		}

	}
	
}
