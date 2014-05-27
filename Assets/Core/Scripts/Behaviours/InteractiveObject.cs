using UnityEngine;

public abstract class InteractiveObject : MonoBehaviour {

	public virtual void DoDefocus() {
		OrderManager.ClearTarget();
	}

	public virtual void DoFocus() {
		OrderManager.SetTarget(this);
	}

	public virtual void DoLook() {}

	public virtual void DoTeleport() {}

	public virtual void DoWalk() {}
	
	public void OnMouseEnter() {
		InputManager.NotifyOnMouseEnter(this);
	}
	
	public void OnMouseExit() {
		InputManager.NotifyOnMouseExit(this);
	}

}
