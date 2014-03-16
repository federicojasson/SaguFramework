using UnityEngine;

public class Game : MonoBehaviour {

	public void Awake() {
		ConfigurationManager.LoadConfiguration();
		LanguageManager.LoadLanguage(ConfigurationManager.GetLanguageId());
	}

	public void Update() {
		CursorManager.CheckInput();
	}

}

/*using UnityEngine;

public class Game : MonoBehaviour {
	
	private static Game instance;
	public Language language;
	public PlayerCharacter playerCharacter;

	public static PlayerCharacter GetPlayerCharacter() {
		return Game.instance.playerCharacter;
	}

	public void Awake() {
		Game.instance = this;
	}

	public void Start() {
		InitializeLanguageManager();
		Invoke("InitializeCursorManager", P.DELAY_INITIALIZE_CURSOR_MANAGER);
	}

	public void Update() {
		CursorManager.CheckInput();
	}

	private void InitializeCursorManager() {
		CursorManager.SetAction(CursorManager.GetAction());
		CursorManager.ActivateInputCheck();
	}

	private void InitializeLanguageManager() {
		LanguageManager.SetLanguage(language);
	}

}*/
