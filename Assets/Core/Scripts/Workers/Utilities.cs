using UnityEngine;

public partial class Utilities : MonoBehaviour {

	public Timer TimerModel;
	
	public void Awake() {
		instance = this;
	}

}
