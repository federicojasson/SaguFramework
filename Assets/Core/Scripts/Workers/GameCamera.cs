using UnityEngine;

namespace SaguFramework {

	public partial class GameCamera : MonoBehaviour {

		private Rect boundaries;
		private bool isActiveTarget;
		private Transform target;

		public void Awake() {
			// Sets itself as the singleton instance
			instance = this;

			// Sets the orthographic size
			camera.orthographicSize = UtilityManager.GetCameraOrthographicSizeUnits();

			// Sets the background color
			camera.backgroundColor = ParameterManager.GetCameraBackgroundColor();
		}

		public void LateUpdate() {
			if (target != null) {
				// When the target is active, the camera is the one that moves
				// On the other hand, if the target is pasive, it gets moved in front of the camera
				if (isActiveTarget) {
					// TODO: comments
					/*Vector3 position = UtilityManager.GetPosition(target.position, transform.position.z);
					float x = Mathf.Clamp(position.x, boundaries.xMin, boundaries.xMax);
					float y = Mathf.Clamp(position.y, boundaries.yMin, boundaries.yMax);
					//transform.position = new Vector3(x, y, position.z); TODO
					transform.position = new Vector3(boundaries.width, boundaries.y, position.z);*/

					target.position = UtilityManager.GetPosition(new Vector3(UtilityManager.GameToWorldX(2), UtilityManager.GameToWorldY(1), 0), target.position.z);

					float gameHalfWidthUnits = UtilityManager.GetGameWidthUnits() / 2f;
					float xMin = boundaries.x;
					float xMax = xMin + boundaries.width;
					float x = Mathf.Clamp(target.position.x, xMin + gameHalfWidthUnits, xMax - gameHalfWidthUnits);

					float gameHalfHeightUnits = UtilityManager.GetGameHeightUnits() / 2f;
					float yMin = boundaries.y - boundaries.height;
					float yMax = yMin + boundaries.height;
					float y = Mathf.Clamp(target.position.y, yMin + gameHalfHeightUnits, yMax - gameHalfHeightUnits);

					Debug.Log ("boundaries.xMin: " + boundaries.xMin);
					Debug.Log ("boundaries.xMax: " + boundaries.xMax);
					Debug.Log ("boundaries.yMin: " + boundaries.yMin);
					Debug.Log ("boundaries.yMax: " + boundaries.yMax);
					Debug.Log ("gameWidth / 2: " + gameHalfWidthUnits);
					Debug.Log ("gameHeight / 2: " + gameHalfHeightUnits);
					Debug.Log ("X: " + x);
					Debug.Log ("Y: " + y);

					transform.position = new Vector3(x, y, transform.position.z);

				} else
					target.position = UtilityManager.GetPosition(transform.position, target.position.z);
			}
		}

		public void SetBoundaries(Rect boundaries) {
			this.boundaries = boundaries;
		}

		public void SetTarget(Transform target, bool isActiveTarget) {
			this.isActiveTarget = isActiveTarget;
			this.target = target;
		}

	}

}
