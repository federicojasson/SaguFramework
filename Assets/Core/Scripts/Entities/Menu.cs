using UnityEngine;

public class Menu : MonoBehaviour {

	public FadeParameters FadeInParameters;
	public FadeParameters FadeOutParameters;
	public GameImage Image;

	public virtual void Awake() {
		// Hides the menu initially
		Hide();
	}

	public void Close() {
		Destroy(gameObject);
	}
	
	public void Hide() {
		enabled = false;
	}
	
	public void Show() {
		enabled = true;
	}

}
