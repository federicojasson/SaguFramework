using UnityEngine;

public partial class FrameworkAssets : MonoBehaviour {

	public Timer TimerPrefab;

	public void Awake() {
		instance = this;
	}
	
}
