using UnityEngine;

public class DrawerBehaviour : MonoBehaviour {
	
	public void Awake() {
		Drawer.SetBehaviour(this);
	}
	
}
