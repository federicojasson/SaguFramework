using UnityEngine;

public class StateManagerBehaviour : MonoBehaviour {
	
	public void Awake() {
		StateManager.SetBehaviour(this);
	}
	
}
