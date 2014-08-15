using UnityEngine;

public class ConfigurationManagerWorker : MonoBehaviour {

	public string MainMenuId;
	public string MainMenuScene;
	public float MainSplashScreenCurtainFadeInSpeed;
	public float MainSplashScreenCurtainFadeOutSpeed;
	public float MainSplashScreenMinimumDelayTime;
	public float RoomCurtainFadeInSpeed;
	public float RoomCurtainFadeOutSpeed;
	public float RoomMinimumDelayTime;
	public float SplashScreenCurtainFadeInSpeed;
	public float SplashScreenCurtainFadeOutSpeed;
	public float SplashScreenMinimumDelayTime;
	public string StateFilesDirectoryPath;
	public bool UseSplashScreens;

	public void Awake() {
		ConfigurationManager.SetWorker(this);
	}
	
}
