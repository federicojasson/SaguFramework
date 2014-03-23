using UnityEngine;

public class Game : MonoBehaviour {

	public Room room;
	private static Game instance;
	private PlayerCharacter playerCharacter;

	public static PlayerCharacter GetPlayerCharacter() {
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
	}

}
