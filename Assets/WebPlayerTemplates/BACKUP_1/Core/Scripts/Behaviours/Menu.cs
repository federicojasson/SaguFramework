using UnityEngine;

//
// Menu - Behaviour class
//
// TODO: write class description
//
public abstract class Menu : MonoBehaviour {

	public void Awake() {
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
