using UnityEngine;

public partial class FrameworkAssets : MonoBehaviour {

	public GameImage GameImagePrefab;
	public Timer TimerPrefab;

	public void Awake() {
		instance = this;
	}
	
}
