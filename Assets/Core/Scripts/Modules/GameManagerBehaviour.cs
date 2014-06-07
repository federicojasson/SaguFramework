using UnityEngine;

public class GameManagerBehaviour : MonoBehaviour {
	
	public void Awake() {
		GameManager.SetBehaviour(this);
	}
	
}
