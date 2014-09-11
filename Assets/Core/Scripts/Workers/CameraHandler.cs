using UnityEngine;

namespace SaguFramework {
	
	public class CameraHandler : Worker {

		private static CameraHandler instance;

		public static Vector2 GetCameraPosition() {
			return instance.transform.position;
		}

		public override void Awake() {
			base.Awake();
			instance = this;
			gameObject.AddComponent<Camera>();
			camera.backgroundColor = Parameters.GetCameraBackgroundColor();
			camera.isOrthoGraphic = true;
			camera.orthographicSize = 0.5f * Geometry.GetScreenHeightInUnits();
		}

	}
	
}
