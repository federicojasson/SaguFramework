using UnityEngine;

public class InputManagerBehaviour : MonoBehaviour {
	
	public void Awake() {
		InputManager.SetBehaviour(this);
	}

	public void Update() {
		InputManager.CheckInput();
	}
	
}
