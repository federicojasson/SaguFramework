using UnityEngine;

public class UtilityManagerWorker : MonoBehaviour {
	
	public Timer TimerModel;

	public void Awake() {
		UtilityManager.SetWorker(this);
	}
	
}
