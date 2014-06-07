using UnityEngine;

public class CameraManagerBehaviour : MonoBehaviour {
	
	public void Awake() {
		CameraManager.SetBehaviour(this);
	}
	
}
