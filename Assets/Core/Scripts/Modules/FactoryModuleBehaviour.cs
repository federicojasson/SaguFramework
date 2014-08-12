using UnityEngine;

public class FactoryModuleBehaviour : MonoBehaviour {

	public Timer timerModel;

	public void Awake() {
		FactoryModule.SetBehaviour(this);
	}
	
}
