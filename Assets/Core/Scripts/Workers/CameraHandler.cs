using UnityEngine;

namespace SaguFramework {

	/// Handles the game's camera.
	/// The camera can follow a target and has boundaries in which it can move.
	public sealed class CameraHandler : Worker {

		private static Rect boundaries; // The camera's boundaries
		private static CameraHandler instance; // The instance of this worker
		private static Entity target; // The camera's target

		/// Returns the camera's position in world space.
		public static Vector2 GetCameraPosition() {
			return instance.transform.position;
		}

		/// Converts a position in screen space to world space.
		/// The conversion depends on the camera's current position.
		public static Vector2 ScreenToWorldPosition(Vector2 position) {
			return instance.camera.ScreenToWorldPoint(position);
		}
		
		/// Sets the camera's boundaries.
		/// The boundaries are represented by a rectangle in world space.
		public static void SetCameraBoundaries(Rect boundaries) {
			CameraHandler.boundaries = boundaries;
		}

		/// Sets the camera's target.
		/// The target must be an entity.
		public static void SetCameraTarget(Entity target) {
			CameraHandler.target = target;
		}

		public override void Awake() {
			base.Awake();

			// Sets this object as the instance of this worker
			instance = this;

			// Sets the camera's depth (Z value)
			transform.position = Utilities.GetVector3(transform.position, Parameters.DepthCamera);
			
			// Adds a camera
			gameObject.AddComponent<Camera>();

			// Sets the camera's background color and far clip plane
			camera.backgroundColor = Parameters.GetCameraBackgroundColor();
			camera.farClipPlane = Mathf.Abs(transform.position.z);

			// The orthographic size in orthographic mode is half of the vertical size of the viewing volume
			camera.isOrthoGraphic = true;
			camera.orthographicSize = 0.5f * Geometry.GetScreenHeightInUnits();
		}
		
		public void LateUpdate() {
			if (target != null) {
				// There is a target

				// Gets the target's position in world space
				Vector2 targetPosition = target.GetPosition();

				// Calculates the X value to follow the target within the boundaries
				float gameWidthInUnits = Geometry.GetGameWidthInUnits();
				float minimumX = boundaries.x + 0.5f * gameWidthInUnits;
				float maximumX = boundaries.x + boundaries.width - 0.5f * gameWidthInUnits;
				float x = Mathf.Clamp(targetPosition.x, minimumX, maximumX);

				// Calculates the Y value to follow the target within the boundaries
				float gameHeightInUnits = Geometry.GetGameHeightInUnits();
				float minimumY = boundaries.y + 0.5f * gameHeightInUnits;
				float maximumY = boundaries.y + boundaries.height - 0.5f * gameHeightInUnits;
				float y = Mathf.Clamp(targetPosition.y, minimumY, maximumY);

				// Updates the camera's position in world space
				transform.position = new Vector3(x, y, transform.position.z);
			}
		}

	}
	
}
