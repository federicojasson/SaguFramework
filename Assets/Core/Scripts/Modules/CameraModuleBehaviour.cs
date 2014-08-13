using UnityEngine;

public class CameraModuleBehaviour : MonoBehaviour {
	
	public Camera Camera;
	
	public void Awake() {
		CameraModule.SetBehaviour(this);
	}
	
}
