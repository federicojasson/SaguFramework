using UnityEngine;

public class ActionManagerBehaviour : MonoBehaviour {
	
	public void Awake() {
		ActionManager.SetBehaviour(this);
	}
	
}
