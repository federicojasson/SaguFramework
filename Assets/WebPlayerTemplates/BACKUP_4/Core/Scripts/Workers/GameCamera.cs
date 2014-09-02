using UnityEngine;

namespace SaguFramework {

	public partial class GameCamera : MonoBehaviour {

		private Rect boundaries;
		private Transform target;

		public void Awake() {
			// Sets itself as the singleton instance
			instance = this;

			// Sets the background color
			camera.backgroundColor = ParameterManager.GetCameraBackgroundColor();

			// Sets the orthographic size
			camera.orthographicSize = UtilityManager.GetScreenHeightUnits() / 2f;

			// Moves the camera to the center of the game rectangle
			Rect gameRectangle = UtilityManager.GetGameRectangleInWorld();
			float gameRectangleCenterX = gameRectangle.x + gameRectangle.width / 2f;
			float gameRectangleCenterY = gameRectangle.y - gameRectangle.height / 2f;
			Vector2 gameRectangleCenter = new Vector2(gameRectangleCenterX, gameRectangleCenterY);
			transform.position = UtilityManager.GetPosition(gameRectangleCenter, transform.position.z);
		}

		public void LateUpdate() {
			if (target != null) {
				// Calculates the X value to stay between the boundaries
				float gameHalfWidthUnits = UtilityManager.GetGameWidthUnits() / 2f;
				float minimumX = boundaries.x + gameHalfWidthUnits;
				float maximumX = minimumX + boundaries.width - gameHalfWidthUnits;
				float x = Mathf.Clamp(target.position.x, minimumX, maximumX);

				// Calculates the Y value to stay between the boundaries
				float gameHalfHeightUnits = UtilityManager.GetGameHeightUnits() / 2f;
				float minimumY = boundaries.y - boundaries.height + gameHalfHeightUnits;
				float maximumY = minimumY + boundaries.height - gameHalfHeightUnits;
				float y = Mathf.Clamp(target.position.y, minimumY, maximumY);

				// Sets the camera's position
				transform.position = new Vector3(x, y, transform.position.z);
			}
		}

		public void MoveInFront(Transform target) {
			// Moves the target in front of the camera
			target.position = UtilityManager.GetPosition(transform.position, target.position.z);
		}

		public void SetBoundaries(Rect boundaries) {
			this.boundaries = boundaries;
		}

		public void SetTarget(Transform target) {
			this.target = target;
		}

	}

}
