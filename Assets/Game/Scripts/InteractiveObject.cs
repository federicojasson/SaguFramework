using UnityEngine;

public abstract class InteractiveObject : MonoBehaviour {

	public string cursorLabelTextId;
	private string cursorLabelText;

	public void Awake() {
		cursorLabelText = LanguageManager.GetText(cursorLabelTextId);
	}

	public string GetCursorLabelText() {
		return cursorLabelText;
	}

	public virtual void OnAction(int action) {
		// TODO
		Debug.Log("OnAction: " + action);
	}

	public void void OnMouseDown() {
		CursorManager.NotifyLeftClick(this);
	}

	public void OnMouseEnter() {
		CursorManager.NotifyCursorEnter(this);
	}

	public void OnMouseExit() {
		CursorManager.NotifyCursorExit(this);
	}

}

/*using UnityEngine;

public class InteractiveObject : MonoBehaviour {

	public string cursorLabelTextId;
	private string cursorLabelText;

	public void Awake() {
		cursorLabelText = Language.GetText(cursorLabelTextId);
	}

	public virtual void OnMouseDown() {
		switch (CursorManager.GetAction()) {
			case P.ACTION_LOOK : {
				OnLook();
				break;
			}
		}
	}

	public virtual void OnMouseEnter() {
		CursorManager.SetLabel(cursorLabelText);
	}
	
	public virtual void OnMouseExit() {
		CursorManager.ClearLabel();
	}
	
	protected virtual void OnLook() {}

}*/
