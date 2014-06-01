using UnityEngine;

public class TestCoordinates : MonoBehaviour {

	private bool activated;

	public void Start() {
		activated = false;
	}
	
	public void Update() {
		if (Input.GetMouseButtonDown(0))
			activated = ! activated;

		if (activated) {
			//Debug.Log("Screen coordinates: " + );
			/*Vector2 screenCoordinates = (Vector2) Input.mousePosition;
			Vector2 worldCoordinates = Camera.main.ScreenToWorldPoint(screenCoordinates);
			Vector2 viewportCoordinates = Camera.main.ScreenToViewportPoint(screenCoordinates);

			Debug.Log("Screen coordinates: " + screenCoordinates);
			Debug.Log("World coordinates: " + worldCoordinates);
			Debug.Log("Viewport coordinates: " + viewportCoordinates);*/
			Debug.Log ("Screen: " + Screen.width + ", " + Screen.height);
			Debug.Log ("Camera: " + Camera.main.pixelWidth + ", " + Camera.main.pixelHeight);
		}
	}
	
}
