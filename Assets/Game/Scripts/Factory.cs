/*using UnityEngine;

public class Factory : MonoBehaviour {
	
	private static Factory instance;
	public CursorLabel cursorLabelModel;
	public GUIText speechTextModel;
	public GUISkin skin;
	public Texture2D cursorLookTexture;
	public Texture2D cursorTeleportTexture;
	public Texture2D cursorWalkTexture;
	private CursorLabel cursorLabel;
	private GUIText speechText;

	public static void DisposeCursorLabel() {
		Factory.instance.cursorLabel.gameObject.SetActive(false);
	}

	public static void DisposeSpeechText() {
		Factory.instance.speechText.gameObject.SetActive(false);
	}
	
	public static CursorLabel GetCursorLabel(string text) {
		CursorLabel cursorLabel = Factory.instance.cursorLabel;
		cursorLabel.gameObject.SetActive(true);
		cursorLabel.SetText(text);
		return cursorLabel;
	}
	
	public static Texture2D GetCursorLookTexture() {
		return Factory.instance.cursorLookTexture;
	}

	public static Texture2D GetCursorTeleportTexture() {
		return Factory.instance.cursorTeleportTexture;
	}
	
	public static Texture2D GetCursorWalkTexture() {
		return Factory.instance.cursorWalkTexture;
	}

	public static GUISkin GetSkin() {
		return Factory.instance.skin;
	}
	
	public static GUIText GetSpeechText(string text, Vector2 position) {
		GUIText speechText = Factory.instance.speechText;
		speechText.gameObject.SetActive(true);
		speechText.text = text;
		speechText.transform.position = new Vector3(position.x, position.y, speechText.transform.position.z);
		return speechText;
	}

	public void Awake() {
		Factory.instance = this;

		cursorLabel = (CursorLabel) Instantiate(cursorLabelModel);
		cursorLabel.gameObject.SetActive(false);

		speechText = (GUIText) Instantiate(speechTextModel);
		speechText.gameObject.SetActive(false);
	}

}*/
