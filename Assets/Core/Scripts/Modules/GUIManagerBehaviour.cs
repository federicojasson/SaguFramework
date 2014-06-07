using UnityEngine;

public class GUIManagerBehaviour : MonoBehaviour {
	
	public void Awake() {
		GUIManager.SetBehaviour(this);
	}
	
}
