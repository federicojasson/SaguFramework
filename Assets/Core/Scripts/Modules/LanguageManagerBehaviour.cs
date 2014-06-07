using UnityEngine;

public class LanguageManagerBehaviour : MonoBehaviour {
	
	public void Awake() {
		LanguageManager.SetBehaviour(this);
	}
	
}
