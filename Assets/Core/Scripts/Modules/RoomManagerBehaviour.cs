using UnityEngine;

public class RoomManagerBehaviour : MonoBehaviour {
	
	public void Awake() {
		RoomManager.SetBehaviour(this);
	}
	
}
