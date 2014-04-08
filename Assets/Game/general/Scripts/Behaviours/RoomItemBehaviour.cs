public class RoomItemBehaviour : InteractiveObject {

	public string cursorLabelTextId;
	public string onOrderLookSpeechId;
	private string cursorLabelText;
	private Speech onOrderLookSpeech;

	public void Awake() {
		cursorLabelText = LanguageManager.GetText(cursorLabelTextId);
		onOrderLookSpeech = LanguageManager.GetSpeech(onOrderLookSpeechId);
	}

	public override void OnDefocus() {
		InputManager.ClearCursorLabel();
	}
	
	public override void OnFocus() {
		InputManager.SetCursorLabel(cursorLabelText);
	}
	
	public override void OnOrderLook() {
		// TODO
		UnityEngine.Debug.Log("walk to object and say: " + onOrderLookSpeech.GetText());
	}

	public override void OnQuickOrderLook() {
		// TODO
		UnityEngine.Debug.Log("say: " + onOrderLookSpeech.GetText());
	}

}
