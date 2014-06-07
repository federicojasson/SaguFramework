using UnityEngine;

public class Song : MonoBehaviour {

	public void Awake() {
		DontDestroyOnLoad(this);
	}

	public void Start() {
		audio.Play();
	}
	
}
