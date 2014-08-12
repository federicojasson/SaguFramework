using UnityEngine;

public class ConfigurationModuleBehaviour : MonoBehaviour {

	public bool gameHasMainMenu; // Determines whether the game has a main menu
	public string mainMenuRoom; // Determines the main menu room (only relevant if gameHasMainMenu == true)
	public float mainSplashScreenCurtainFadeInSpeed; // Alpha channel units per second
	public float mainSplashScreenCurtainFadeOutSpeed; // Alpha channel units per second
	public float mainSplashScreenMinimumDelayTime; // Time in seconds
	public float roomCurtainFadeInSpeed; // Alpha channel units per second
	public float roomCurtainFadeOutSpeed; // Alpha channel units per second
	public float roomMinimumDelayTime; // Time in seconds
	public float splashScreenCurtainFadeInSpeed; // Alpha channel units per second
	public float splashScreenCurtainFadeOutSpeed; // Alpha channel units per second
	public float splashScreenMinimumDelayTime; // Time in seconds

	public void Awake() {
		ConfigurationModule.SetBehaviour(this);
	}
	
}
