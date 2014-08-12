using UnityEngine;

public class InputModuleBehaviour : MonoBehaviour {
	
	public void Awake() {
		InputModule.SetBehaviour(this);
	}

	public void Update() {
		InputModule.CheckInput();
	}
	
}
