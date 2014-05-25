using System.Collections;
using UnityEngine;

public class MainLoader : MonoBehaviour {

	public Curtain curtain;
	public Menu mainMenu;

	public void Awake() {
		// Shows the background
		curtain.ShowBackground();
		
		// Shows a random splash screen (if there is any)
		curtain.ShowRandomSplashScreen();

		// Loads resources asynchronously
		StartCoroutine(LoadCoroutine());
	}

	private IEnumerator LoadCoroutine() {
		// Loads the configurations and the language
		ConfigurationManager.LoadConfigurations();
		LanguageManager.LoadLanguage(ConfigurationManager.GetConfiguration(C.CONFIGURATION_ID_LANGUAGE));
		yield return new WaitForSeconds(1); // TODO: debugging

		// Shows the background
		curtain.ShowBackground();

		// Shows the main menu
		GUIManager.ShowMenu(mainMenu);

		yield break;
	}
	
}
