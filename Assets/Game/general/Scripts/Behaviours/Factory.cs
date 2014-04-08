using UnityEngine;

public class Factory : MonoBehaviour {

	public CursorLabel cursorLabelModel;
	public Texture2D cursorLookTexture;
	public Texture2D cursorTeleportTexture;
	public Texture2D cursorWaitTexture;
	public Texture2D cursorWalkTexture;
	public RoomItemBehaviour erlenmeyerModel;
	public CharacterBehaviour scientistModel;
	public GUISkin skin;
	private static Factory instance;
	private CursorLabel cursorLabel;

	public static void CreateCharacter(Character character) {
		switch (character.GetId()) {
			case "Scientist" : {
				Factory.instance.CreateScientist(character.GetPosition());
				break;
			}
		}
	}

	public static void CreateRoomItem(RoomItem roomItem) {
		switch (roomItem.GetId()) {
			case "Erlenmeyer" : {
				Factory.instance.CreateErlenmeyer(roomItem.GetPosition());
				break;
			}
		}
	}

	public static Texture2D GetCursorTexture(int cursorActionId) {
		switch (cursorActionId) {
			case P.ORDER_LOOK : return Factory.instance.cursorLookTexture;
			case P.ORDER_TELEPORT : return Factory.instance.cursorTeleportTexture;
			case P.ORDER_WAIT : return Factory.instance.cursorWaitTexture;
			case P.ORDER_WALK : return Factory.instance.cursorWalkTexture;
			default : return null;
		}
	}

	public static GUISkin GetSkin() {
		return Factory.instance.skin;
	}
	
	public static void HideCursorLabel() {
		Utility.DisableComponent(Factory.instance.cursorLabel);
	}

	public static void ShowCursorLabel(string text) {
		CursorLabel cursorLabel = Factory.instance.cursorLabel;
		Utility.EnableComponent(cursorLabel);
		cursorLabel.SetText(text);
	}

	public void Awake() {
		Factory.instance = this;

		cursorLabel = (CursorLabel) Instantiate(cursorLabelModel);
		Utility.DisableComponent(cursorLabel);
	}

	private void CreateErlenmeyer(Vector2 position) {
		RoomItemBehaviour erlenmeyer = (RoomItemBehaviour) Instantiate(erlenmeyerModel);
		erlenmeyer.transform.position = position;
	}

	private void CreateScientist(Vector2 position) {
		CharacterBehaviour scientist = (CharacterBehaviour) Instantiate(scientistModel);
		scientist.transform.position = position;
	}

	// TODO
	/*public CursorLabel cursorLabelModel;
	public Character playerCharacterModel;
	public SpeechText speechTextModel;
	private static Factory instance;
	private CursorLabel cursorLabel;
	private Character playerCharacter;
	private SpeechText speechText;

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

	public static Character GetPlayerCharacter(Vector2 position) {
		Character playerCharacter = Factory.instance.playerCharacter;
		Utility.EnableComponent(playerCharacter);
		playerCharacter.transform.position = Utility.ToVector3(position, playerCharacter.transform.position.z);
		return playerCharacter;
	}

	public static SpeechText GetSpeechText(Character character, string text) {
		SpeechText speechText = Factory.instance.speechText;
		Utility.EnableComponent(speechText);
		speechText.SetCharacter(character);
		speechText.SetText(text);
		return speechText;
	}

	public void Awake() {
		Factory.instance = this;
		
		cursorLabel = (CursorLabel) Instantiate(cursorLabelModel);
		Utility.DisableComponent(cursorLabel);

		playerCharacter = (Character) Instantiate(playerCharacterModel);
		Utility.DisableComponent(playerCharacter);

		speechText = (SpeechText) Instantiate(speechTextModel);
		Utility.DisableComponent(speechText);
	}*/

}
