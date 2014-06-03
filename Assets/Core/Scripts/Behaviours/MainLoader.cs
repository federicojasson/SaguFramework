using System.Collections;
using UnityEngine;

//
// MainLoader - Behaviour class
//
// TODO: write class description
//
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
		float beginTime = Time.time;

		// Loads the configurations and the language
		ConfigurationManager.LoadConfigurations();
		LanguageManager.LoadLanguage(ConfigurationManager.GetConfiguration(C.CONFIGURATION_ID_LANGUAGE));

		// Sets the game audio volume
		float volume = Parser.StringToFloat(ConfigurationManager.GetConfiguration(C.CONFIGURATION_ID_VOLUME));
		AudioManager.SetVolume(volume);

		float endTime = Time.time;
		float loadTime = endTime - beginTime;
		float minimumLoadTime = 2; // TODO: set somehow else

		if (loadTime < minimumLoadTime)
			yield return new WaitForSeconds(minimumLoadTime - loadTime);

		// Shows the background
		curtain.ShowBackground();

		// TODO: block somehow until fade out completed?

		// Shows the main menu
		GUIManager.ShowMenu(mainMenu);

		yield break;
	}
	
}
