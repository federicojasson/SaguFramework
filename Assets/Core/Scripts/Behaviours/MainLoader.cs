using System.Collections;
using UnityEngine;

public class MainLoader : MonoBehaviour {

	public BackgroundObject backgroundObject;
	public Menu mainMenu;

	public void Awake() {
		// Shows the first sprite (main splash screen or main background)
		backgroundObject.SetSprite(0);

		// Loads resources asynchronously
		StartCoroutine(LoadCoroutine());
	}

	private IEnumerator LoadCoroutine() {
		// Loads the configurations and the language
		ConfigurationManager.LoadConfigurations();
		LanguageManager.LoadLanguage(ConfigurationManager.GetConfiguration(C.CONFIGURATION_ID_LANGUAGE));
		yield return new WaitForSeconds(1); // TODO: debugging

		if (backgroundObject.GetSpriteCount() > 1)
			// Shows the next sprite (main background)
			backgroundObject.SetNextSprite();

		// Shows the main menu
		GUIManager.ShowMenu(mainMenu);

		yield break;
	}
	
}
