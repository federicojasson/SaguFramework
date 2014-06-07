using UnityEngine;

public class CameraManagerBehaviour : MonoBehaviour {

	public Camera camera;

	public void Awake() {
		CameraManager.SetBehaviour(this);
	}
	
}
