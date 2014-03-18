using UnityEngine;

public class CursorLabel : MonoBehaviour {

	private string text;

	public void Awake() {
		text = "";
	}

	public void OnGUI() {
		GUI.skin = Factory.GetSkin();
		Vector2 position = Utility.GetCursorScreenPosition() + P.OFFSET_CURSOR_LABEL;
		GUI.Label(Utility.GetLabelRectangle(position, text), text);
	}

	public void SetText(string text) {
		this.text = text;
	}

}
