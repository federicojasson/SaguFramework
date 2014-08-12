using UnityEngine;

public class ParameterModuleBehaviour : MonoBehaviour {
	
	public void Awake() {
		ParameterModule.SetBehaviour(this);
	}
	
}
