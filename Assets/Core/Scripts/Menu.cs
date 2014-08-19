using UnityEngine;

public class Menu : MonoBehaviour {
	
	public Sprite Background;
	public FadeParameters FadeParameters;

	public void Awake() {
		// Hides the menu
		enabled = false;
	}

}
