using System.Collections;
using UnityEngine;

public class GameLoader : MonoBehaviour {

	public void Awake() {
		// TODO: show initial splash
		Debug.Log("Show initial splash");
		
		enabled = false;
		StartCoroutine(LoadCoroutine());
	}

	public void OnGUI() {
		string newGameButtonText = LanguageManager.GetText("NEW_GAME_MENU_BUTTON");
		if (GUI.Button(Utility.GetMenuButtonRectangle(new Vector2(80, 40), newGameButtonText), newGameButtonText))
			SavegameManager.NewGame();

		string loadGameButtonText = LanguageManager.GetText("LOAD_GAME_MENU_BUTTON");
		if (GUI.Button(Utility.GetMenuButtonRectangle(new Vector2(80, 80), loadGameButtonText), loadGameButtonText))
			SavegameManager.LoadGame();
	}

	private IEnumerator LoadCoroutine() {
		ConfigurationManager.LoadConfigurations();
		LanguageManager.LoadLanguage(ConfigurationManager.GetLanguageId());
		
		// TODO: quitar splash
		Debug.Log("Hide initial splash");
		
		enabled = true;
		yield break;
	}

}
