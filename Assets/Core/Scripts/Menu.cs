using UnityEngine;

public class Menu : MonoBehaviour {
	
	public Sprite Background;
	public FadeParameters FadeParameters;

	public virtual void Awake() {
		// Hides the menu initially
		Hide();
	}
	
	public void Hide() {
		enabled = false;
	}
	
	public void Show() {
		enabled = true;
	}

}
