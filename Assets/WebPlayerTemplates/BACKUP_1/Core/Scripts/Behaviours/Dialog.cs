using UnityEngine;

//
// Dialog - Behaviour class
//
// TODO: write class description
//
public abstract class Dialog : MonoBehaviour {
	
	public void Awake() {
		// Hides the dialog initially
		Hide();
	}

	public void Hide() {
		enabled = false;
	}

	public void OnGUI() {
		// The dialog is effectively drawn by OnGUIDialog
		GUIManager.DrawModalWindow(GetTitle(), GetX(), GetY(), GetWidth(), GetHeight(), OnGUIDialog);
	}

	public void Show() {
		enabled = true;
	}
	
	protected abstract float GetHeight();

	protected abstract string GetTitle();
	
	protected abstract float GetWidth();

	protected abstract float GetX();

	protected abstract float GetY();

	protected abstract void OnGUIDialog(int id);
	
}
