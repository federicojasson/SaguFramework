using UnityEngine;

public class RoomModuleBehaviour : MonoBehaviour {
	
	public void Awake() {
		RoomModule.SetBehaviour(this);
	}
	
}
