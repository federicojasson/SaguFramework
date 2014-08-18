using UnityEngine;

public class PersistentBehaviour : MonoBehaviour {
	
	public void Awake() {
		// Prevents this object from being destroyed when the scene changes
		DontDestroyOnLoad(this);
	}
	
}
