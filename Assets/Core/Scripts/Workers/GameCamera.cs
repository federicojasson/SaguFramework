using UnityEngine;

public class GameCamera : MonoBehaviour {
	
	public void Awake() {
		camera.orthographicSize = UtilityManager.GetCameraOrthographicSizeUnits();
	}
	
	public void LateUpdate() {
		// TODO: follow character
	}
	
}
