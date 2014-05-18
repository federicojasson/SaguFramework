using System.Collections;
using UnityEngine;

public class MainLoader : MonoBehaviour {

	public BackgroundObject backgroundObject;
	public Menu mainMenu;

	public void Awake() {
		// Shows the first sprite
		backgroundObject.SetSprite(0);

		// Loads configurations and resources asynchronously
		StartCoroutine(LoadCoroutine());
	}

	private IEnumerator LoadCoroutine() {
		// TODO: load configurations and resources
		Debug.Log("TODO: load configurations and resources");
		ConfigurationManager.LoadConfigurations();
		LanguageManager.LoadLanguage(ConfigurationManager.GetConfiguration(C.CONFIGURATION_ID_LANGUAGE));
		yield return new WaitForSeconds(1); // TODO: debugging

		if (backgroundObject.GetSpriteCount() > 1)
			// Shows the next sprite
			backgroundObject.SetNextSprite();

		// Shows the main menu
		MenuManager.ShowMenu(mainMenu);

		yield break;
	}
	
}
