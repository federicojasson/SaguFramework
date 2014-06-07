using UnityEngine;

public class ItemManagerBehaviour : MonoBehaviour {
	
	public void Awake() {
		ItemManager.SetBehaviour(this);
	}
	
}
