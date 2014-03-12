using UnityEngine;

public class FollowerLabel : MonoBehaviour {

	private Vector2 offset;
	private string text;
	
	public void Awake() {
		offset = Vector2.zero;
		text = "";
	}
	
	public void OnGUI() {
		// TODO: label style
		Vector2 position = CursorManager.GetCursorScreenPosition() + offset;
		GUI.Label(Utility.GetTextRectangle(position, text), text);
	}
	
	public void SetOffset(Vector2 offset) {
		this.offset = offset;
	}
	
	public void SetText(string text) {
		this.text = text;
	}
	
}
