using UnityEngine;

public class Factory : MonoBehaviour {

	public RoomItemBehaviour erlenmeyerModel;
	public CharacterBehaviour scientistModel;
	private static Factory instance;

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

	public void Awake() {
		Factory.instance = this;
		DontDestroyOnLoad(this);
	}

	private void CreateErlenmeyer(Vector2 position) {
		Debug.Log("create erlenmeyer");
		RoomItemBehaviour erlenmeyer = (RoomItemBehaviour) Instantiate(erlenmeyerModel);
		erlenmeyer.transform.position = position;
	}

	private void CreateScientist(Vector2 position) {
		Debug.Log("create scientist");
		CharacterBehaviour scientist = (CharacterBehaviour) Instantiate(scientistModel);
		scientist.transform.position = position;
	}

	// TODO
	/*public CursorLabel cursorLabelModel;
	public Texture2D cursorLookTexture;
	public Texture2D cursorTeleportTexture;
	public Texture2D cursorWaitTexture;
	public Texture2D cursorWalkTexture;
	public Character playerCharacterModel;
	public GUISkin skin;
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

	public static Character GetPlayerCharacter(Vector2 position) {
		Character playerCharacter = Factory.instance.playerCharacter;
		Utility.EnableComponent(playerCharacter);
		playerCharacter.transform.position = Utility.ToVector3(position, playerCharacter.transform.position.z);
		return playerCharacter;
	}
	
	public static GUISkin GetSkin() {
		return Factory.instance.skin;
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
