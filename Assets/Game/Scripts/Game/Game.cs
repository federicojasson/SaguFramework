using UnityEngine;

public class Game : MonoBehaviour {

	public Room room;
	private static Game instance;
	private Character playerCharacter;

	public static Character GetPlayerCharacter() {
		return Game.instance.playerCharacter;
	}

	public void Awake() {
		Game.instance = this;
		playerCharacter = Factory.GetPlayerCharacter(room.startPosition);

		ConfigurationManager.LoadConfigurations();
		LanguageManager.LoadLanguage(ConfigurationManager.GetLanguageId());
		Invoke("InitializeInputManager", P.DELAY_INITIALIZE_INPUT_MANAGER);
	}

	// TODO: test purposes
	public void Start() {
		playerCharacter.Walk(new Vector2(-0.451f, -0.525f));
		playerCharacter.Say(LanguageManager.GetSpeech("ERLENMEYER_ON_LOOK"));
	}

	public void Update() {
		InputManager.CheckInput();
	}

	private void InitializeInputManager() {
		InputManager.Initialize();
	}

}
