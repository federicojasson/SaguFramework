using UnityEngine;

public class GuiModuleBehaviour : MonoBehaviour {
	
	public void Awake() {
		GuiModule.SetBehaviour(this);
	}
	
}
