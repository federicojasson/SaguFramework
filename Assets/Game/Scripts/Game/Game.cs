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

	public void Update() {
		InputManager.CheckInput();
	}

	private void InitializeInputManager() {
		InputManager.Initialize();

		// TODO: test purposes
		playerCharacter.Walk(new Vector2(-0.451f, -0.525f));
		playerCharacter.Look(new Vector2(-3.832f, -0.525f));
		playerCharacter.Say(LanguageManager.GetSpeech("ERLENMEYER_ON_LOOK"));
	}

}
