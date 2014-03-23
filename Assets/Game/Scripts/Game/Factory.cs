using UnityEngine;

public class Factory : MonoBehaviour {

	public CursorLabel cursorLabelModel;
	public Texture2D cursorLookTexture;
	public Texture2D cursorTeleportTexture;
	public Texture2D cursorWaitTexture;
	public Texture2D cursorWalkTexture;
	public PlayerCharacter playerCharacterModel;
	public GUISkin skin;
	public GUIText speechTextModel;
	private static Factory instance;
	private CursorLabel cursorLabel;
	private PlayerCharacter playerCharacter;
	private GUIText speechText;

	public static void DisposeCursorLabel() {
		Utility.DisableComponent(Factory.instance.cursorLabel);
	}
	
	public static void DisposeSpeechText() {
		Utility.DisableComponent(Factory.instance.speechText);
	}

	public static CursorLabel GetCursorLabel(string text) {
		CursorLabel cursorLabel = Factory.instance.cursorLabel;
		Utility.EnableComponent(cursorLabel);
		cursorLabel.SetText(text);
		return cursorLabel;
	}

	public static Texture2D GetCursorLookTexture() {
		return Factory.instance.cursorLookTexture;
	}
	
	public static Texture2D GetCursorTeleportTexture() {
		return Factory.instance.cursorTeleportTexture;
	}
	
	public static Texture2D GetCursorWaitTexture() {
		return Factory.instance.cursorWaitTexture;
	}
	
	public static Texture2D GetCursorWalkTexture() {
		return Factory.instance.cursorWalkTexture;
	}

	public static PlayerCharacter GetPlayerCharacter(Vector2 position) {
		PlayerCharacter playerCharacter = Factory.instance.playerCharacter;
		Utility.EnableComponent(playerCharacter);
		playerCharacter.transform.position = Utility.ToVector3(position, playerCharacter.transform.position.z);
		return playerCharacter;
	}
	
	public static GUISkin GetSkin() {
		return Factory.instance.skin;
	}

	public static GUIText GetSpeechText(string text, Vector2 position) {
		GUIText speechText = Factory.instance.speechText;
		Utility.EnableComponent(speechText);
		speechText.text = text;
		speechText.transform.position = Utility.ToVector3(position, speechText.transform.position.z);
		return speechText;
	}

	public void Awake() {
		Factory.instance = this;
		
		cursorLabel = (CursorLabel) Instantiate(cursorLabelModel);
		Utility.DisableComponent(cursorLabel);

		playerCharacter = (PlayerCharacter) Instantiate(playerCharacterModel);
		Utility.DisableComponent(playerCharacter);

		speechText = (GUIText) Instantiate(speechTextModel);
		Utility.DisableComponent(speechText);
	}

}
