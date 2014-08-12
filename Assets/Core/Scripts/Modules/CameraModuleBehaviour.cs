using UnityEngine;

public class CameraModuleBehaviour : MonoBehaviour {

	public new Camera camera;

	public void Awake() {
		CameraModule.SetBehaviour(this);
	}
	
}
