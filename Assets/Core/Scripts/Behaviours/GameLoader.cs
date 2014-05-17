using System.Collections;
using UnityEngine;

public class GameLoader : MonoBehaviour {

	public GameObject background;
	public MonoBehaviour mainMenu;
	public Sprite mainMenuBackground;
	public Sprite mainSplashScreen;

	public void Awake() {
		if (background != null && mainSplashScreen != null)
			// Shows the main splash screen
			background.GetComponent<SpriteRenderer>().sprite = mainSplashScreen;

		if (mainMenu != null)
			// Avoids main menu OnGUI being invoked
			mainMenu.enabled = false;

		// Loads configurations and resources asynchronously
		StartCoroutine(LoadCoroutine());
	}

	private IEnumerator LoadCoroutine() {
		// TODO: load configurations and resources
		Debug.Log("TODO: load configurations and resources");
		ConfigurationManager.LoadConfigurations();
		LanguageManager.LoadLanguage(ConfigurationManager.GetConfiguration(C.CONFIGURATION_ID_LANGUAGE));
		yield return new WaitForSeconds(1); // TODO: debugging

		if (background != null && mainMenuBackground != null)
			// Shows the main menu background
			background.GetComponent<SpriteRenderer>().sprite = mainMenuBackground;

		if (mainMenu != null)
			// Allows main menu OnGUI being invoked
			mainMenu.enabled = true;

		yield break;
	}
	
}
