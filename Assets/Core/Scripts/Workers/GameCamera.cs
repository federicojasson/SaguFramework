using UnityEngine;

public class GameCamera : MonoBehaviour {
	
	public void Start() {
		camera.orthographicSize = UtilityManager.GetCameraOrthographicSize();
	}

	public void Update() {
		// TODO: follow character
	}
	
}
