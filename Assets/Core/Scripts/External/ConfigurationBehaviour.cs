using UnityEngine;

public class ConfigurationBehaviour : MonoBehaviour {

	public bool GameHasMainMenu; // Determines whether the game has a main menu
	public string MainMenuRoom; // Determines the main menu room (only relevant if gameHasMainMenu == true)
	public float MainSplashScreenCurtainFadeInSpeed; // Alpha channel units per second
	public float MainSplashScreenCurtainFadeOutSpeed; // Alpha channel units per second
	public float MainSplashScreenMinimumDelayTime; // Time in seconds
	public float RoomCurtainFadeInSpeed; // Alpha channel units per second
	public float RoomCurtainFadeOutSpeed; // Alpha channel units per second
	public float RoomMinimumDelayTime; // Time in seconds
	public float SplashScreenCurtainFadeInSpeed; // Alpha channel units per second
	public float SplashScreenCurtainFadeOutSpeed; // Alpha channel units per second
	public float SplashScreenMinimumDelayTime; // Time in seconds

	public void Awake() {
		Configuration.SetBehaviour(this);
	}
	
}
