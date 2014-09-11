using UnityEngine;

namespace SaguFramework {
	
	public class CameraHandler : Worker {
		
		private static Rect boundaries;
		private static CameraHandler instance;
		private static Component target;
		
		public static void SetCameraBoundaries(Rect boundaries) {
			CameraHandler.boundaries = boundaries;
		}

		public static Vector2 GetCameraPosition() {
			return instance.transform.position;
		}

		public static void SetCameraTarget(Component target) {
			CameraHandler.target = target;
		}

		public override void Awake() {
			base.Awake();
			instance = this;
			gameObject.AddComponent<Camera>();
			camera.backgroundColor = Parameters.GetCameraBackgroundColor();
			camera.isOrthoGraphic = true;
			camera.orthographicSize = 0.5f * Geometry.GetScreenHeightInUnits();
		}

		public void LateUpdate() {
			if (target != null) {
				Vector2 targetPosition = target.transform.position;

				float gameWidthInUnits = Geometry.GetGameWidthInUnits();
				float minimumX = boundaries.x + 0.5f * gameWidthInUnits;
				float maximumX = boundaries.x + boundaries.width - 0.5f * gameWidthInUnits;
				float x = Mathf.Clamp(targetPosition.x, minimumX, maximumX);
				
				float gameHeightInUnits = Geometry.GetGameHeightInUnits();
				float minimumY = boundaries.y - boundaries.height + 0.5f * gameHeightInUnits;
				float maximumY = boundaries.y - 0.5f * gameHeightInUnits;
				float y = Mathf.Clamp(targetPosition.y, minimumY, maximumY);
				
				camera.transform.position = new Vector3(x, y, camera.transform.position.z);
			}
		}

	}
	
}
