using UnityEngine;

public abstract class InteractiveObject : MonoBehaviour {

	public string cursorLabelTextId;
	private string cursorLabelText;

	public string GetCursorLabelText() {
		return cursorLabelText;
	}

	public void OnAction(int actionId) {
		switch (actionId) {
			case P.CURSOR_ACTION_LOOK : {
				OnLook();
				break;
			}
			
			case P.CURSOR_ACTION_TELEPORT : {
				OnTeleport();
				break;
			}
			
			case P.CURSOR_ACTION_WAIT : {
				OnWait();
				break;
			}
			
			case P.CURSOR_ACTION_WALK : {
				OnWalk();
				break;
			}
		}
	}
	
	public virtual void OnDefocus() {
		InputManager.ClearCursorLabel();
	}

	public virtual void OnFocus() {
		InputManager.SetCursorLabel(cursorLabelText);
	}

	public virtual void OnLook() {}

	public void OnMouseDown() {
		InputManager.NotifyLeftClick(this);
	}

	public void OnMouseEnter() {
		InputManager.NotifyCursorEnter(this);
	}

	public void OnMouseExit() {
		InputManager.NotifyCursorExit(this);
	}

	public virtual void OnTeleport() {}

	public virtual void OnWait() {}

	public virtual void OnWalk() {}

	public virtual void Start() {
		cursorLabelText = LanguageManager.GetText(cursorLabelTextId);
	}

}
