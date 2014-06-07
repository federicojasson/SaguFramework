using UnityEngine;

public class SkinManagerBehaviour : MonoBehaviour {
	
	public void Awake() {
		SkinManager.SetBehaviour(this);
	}
	
}
