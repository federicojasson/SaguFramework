using UnityEngine;

public class OptionManagerBehaviour : MonoBehaviour {
	
	public void Awake() {
		OptionManager.SetBehaviour(this);
	}
	
}
