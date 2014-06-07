using UnityEngine;

public class CursorManagerBehaviour : MonoBehaviour {
	
	public void Awake() {
		CursorManager.SetBehaviour(this);
	}
	
}
