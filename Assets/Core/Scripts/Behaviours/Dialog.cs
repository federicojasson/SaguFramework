using UnityEngine;

public abstract class Dialog : MonoBehaviour {
	
	public void Awake() {
		// Disables the dialog to avoid OnGUI being invoked
		enabled = false;
	}

	public void OnGUI() {
		GUIManager.DrawModalWindow(GetTitle(), GetX(), GetY(), GetWidth(), GetHeight(), OnGUIDialog);
	}
	
	protected abstract float GetHeight();

	protected abstract string GetTitle();
	
	protected abstract float GetWidth();

	protected abstract float GetX();

	protected abstract float GetY();

	protected abstract void OnGUIDialog(int id);
	
}
