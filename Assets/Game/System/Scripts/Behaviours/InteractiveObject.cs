using UnityEngine;

public abstract class InteractiveObject : MonoBehaviour {
	
	public virtual void OnDefocus() {}
	
	public virtual void OnFocus() {}

	public void OnMouseDown() {
		InputManager.NotifyLeftClick(this);
	}
	
	public void OnMouseEnter() {
		InputManager.NotifyCursorEnter(this);
	}
	
	public void OnMouseExit() {
		InputManager.NotifyCursorExit(this);
	}
	
	public void OnOrder(int orderId) {
		switch (orderId) {
			case P.ORDER_LOOK : {
				OnOrderLook();
				break;
			}
				
			case P.ORDER_TELEPORT : {
				OnOrderTeleport();
				break;
			}
				
			case P.ORDER_WAIT : {
				OnOrderWait();
				break;
			}
				
			case P.ORDER_WALK : {
				OnOrderWalk();
				break;
			}
		}
	}
	
	public virtual void OnOrderLook() {}
	
	public virtual void OnOrderTeleport() {}
	
	public virtual void OnOrderWait() {}
	
	public virtual void OnOrderWalk() {}
	
	public void OnQuickOrder(int orderId) {
		switch (orderId) {
			case P.ORDER_LOOK : {
				OnQuickOrderLook();
				break;
			}
			
			case P.ORDER_TELEPORT : {
				OnQuickOrderTeleport();
				break;
			}
			
			case P.ORDER_WAIT : {
				OnQuickOrderWait();
				break;
			}
			
			case P.ORDER_WALK : {
				OnQuickOrderWalk();
				break;
			}
		}
	}
	
	public virtual void OnQuickOrderLook() {}
	
	public virtual void OnQuickOrderTeleport() {}
	
	public virtual void OnQuickOrderWait() {}
	
	public virtual void OnQuickOrderWalk() {}

	// TODO
	/*public string cursorLabelTextId;
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

	public virtual void OnTeleport() {}

	public virtual void OnWait() {}

	public virtual void OnWalk() {}

	public virtual void Start() {
		cursorLabelText = LanguageManager.GetText(cursorLabelTextId);
	}*/

}
