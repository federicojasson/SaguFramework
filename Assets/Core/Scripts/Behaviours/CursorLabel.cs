using UnityEngine;

public class CursorLabel : MonoBehaviour {

	private string text;

	public void Awake() {
		// Prevents the cursor label object from being destroyed when the scene changes
		DontDestroyOnLoad(this);

		// Disables the cursor label by default
		enabled = false;
	}

	public void OnGUI() {
		Vector2 gamePoint = CoordinatesManager.ScreenToGamePoint(Input.mousePosition);
		GUIManager.DrawCursorLabel(text, gamePoint.x, gamePoint.y);
	}

	public void SetText(string text) {
		this.text = text;
	}
	
}
