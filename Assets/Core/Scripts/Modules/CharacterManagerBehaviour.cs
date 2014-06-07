using UnityEngine;

public class CharacterManagerBehaviour : MonoBehaviour {
	
	public void Awake() {
		CharacterManager.SetBehaviour(this);
	}
	
}
