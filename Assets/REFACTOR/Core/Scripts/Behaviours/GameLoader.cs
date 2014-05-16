using System.Collections;
using UnityEngine;

public class GameLoader : MonoBehaviour {

	public GameObject background;
	public Menu mainMenu;
	public Sprite mainMenuBackground;
	public Sprite mainSplashScreen;

	public void Awake() {
		if (background != null && mainSplashScreen != null)
			// Shows the main splash screen
			background.GetComponent<SpriteRenderer>().sprite = mainSplashScreen;

		// Avoids OnGUI being invoked
		enabled = false;

		// Loads configurations and resources asynchronously
		StartCoroutine(LoadCoroutine());
	}
	
	public void OnGUI() {
		if (mainMenu != null)
			// Shows the main menu
			mainMenu.Show();
	}

	private IEnumerator LoadCoroutine() {
		// TODO: load configurations and resources
		Debug.Log("TODO: load configurations and resources");
		yield return new WaitForSeconds(3); // TODO: debugging

		if (background != null && mainMenuBackground != null)
			// Shows the main menu background
			background.GetComponent<SpriteRenderer>().sprite = mainMenuBackground;

		// Allows OnGUI being invoked
		enabled = true;

		yield break;
	}
	
}
