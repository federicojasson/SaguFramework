using UnityEngine;

//
// ScreenCamera - Behaviour class
//
// This class adjusts the main camera according to the screen resolution. The script must be attached to the game main
// camera in all scenes.
//
public class ScreenCamera : MonoBehaviour {

	public void Update() {
		float aspectRatio = Screen.width / (float) Screen.height;

		// The orthographic size is half of the vertical size of the viewing volume
		camera.orthographicSize = (C.GAME_SCREEN_ASPECT_RATIO * C.GAME_SCREEN_VERTICAL_UNITS / 2) / aspectRatio;

		Factory.GetSkin().GetStyle(C.SKIN_STYLE_CURSOR_LABEL).fontSize = (int) (Screen.width * 0.01f);
	}
	
}
