using UnityEngine;

public class HelperModuleBehaviour : MonoBehaviour {
	
	public Timer TimerModel;
	
	public void Awake() {
		HelperModule.SetBehaviour(this);
	}
	
}
