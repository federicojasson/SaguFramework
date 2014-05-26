using UnityEngine;

//
// ScreenCamera - Behaviour class
//
// This class adjusts the main camera according to the screen resolution. The script must be attached to the game main
// camera in all scenes.
//
public class ScreenCamera : MonoBehaviour {
	
	public void Awake() {
		float aspectRatio = Screen.width / (float) Screen.height;
		float height = G.SCREEN_ASPECT_RATIO * G.SCREEN_HEIGHT / aspectRatio;

		// The orthographic size is half of the vertical size of the viewing volume
		camera.orthographicSize = (height / 2) / G.SCREEN_PIXELS_PER_UNIT;
	}
	
}
