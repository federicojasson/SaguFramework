using UnityEngine;

public class SplashScreenManagerWorker : MonoBehaviour {

	public SplashScreen MainSplashScreenModel;
	public SplashScreen[] SplashScreenModels;

	public void Awake() {
		SplashScreenManager.SetWorker(this);
	}
	
}
