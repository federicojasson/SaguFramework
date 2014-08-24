using UnityEngine;

public class GameCamera : MonoBehaviour {
	
	public void Start() {
		camera.orthographicSize = UtilityManager.GetCameraOrthographicSizeUnits();
	}

	public void Update() {
		// TODO: follow character
	}
	
}
