using UnityEngine;

public class FactoryBehaviour : MonoBehaviour {

	public Timer timerModel;

	public void Awake() {
		Factory.SetBehaviour(this);
	}
	
}
