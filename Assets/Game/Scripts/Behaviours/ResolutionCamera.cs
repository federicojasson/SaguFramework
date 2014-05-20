using UnityEngine;

public class ResolutionCamera : MonoBehaviour {
	
	public void Awake() {
		float aspectRatio = Screen.width / (float) Screen.height;
		float height = G.SCREEN_ASPECT_RATIO * G.SCREEN_HEIGHT / aspectRatio;
		camera.orthographicSize = (height / 2) / G.SCREEN_PIXELS_PER_UNIT;
	}
	
}
