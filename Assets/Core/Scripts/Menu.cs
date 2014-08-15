using UnityEngine;

public class Menu : MonoBehaviour {

	public void Awake() {
		enabled = false;
	}

	public void Hide() {
		enabled = false;
	}

	public void Show() {
		enabled = true;
	}

}
