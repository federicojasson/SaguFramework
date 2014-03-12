using UnityEngine;

public class InteractiveObject : MonoBehaviour {

	public string description;

	public virtual void OnMouseEnter() {
		CursorManager.SetLabel(description);
	}
	
	public virtual void OnMouseExit() {
		CursorManager.ClearLabel();
	}

}
