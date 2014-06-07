using UnityEngine;

public class FactoryBehaviour : MonoBehaviour {
	
	public void Awake() {
		Factory.SetBehaviour(this);
	}
	
}
