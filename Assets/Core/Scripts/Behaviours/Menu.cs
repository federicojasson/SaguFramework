using UnityEngine;

public class Menu : MonoBehaviour {

	public void Awake() {
		// Disables the menu to avoid OnGUI being invoked
		enabled = false;
	}

}
