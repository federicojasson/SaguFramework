using UnityEngine;

public class PersistentBehaviour : MonoBehaviour {
	
	public void Awake() {
		DontDestroyOnLoad(this);
	}
	
}
