using UnityEngine;

public static class SplashScreenManager {

	private static SplashScreenManagerWorker worker;

	public static void CreateMainSplashScreen() {
		CreateSplashScreen(worker.MainSplashScreenModel);
	}

	public static void CreateRandomSplashScreen() {
		int randomIndex = Random.Range(0, worker.SplashScreenModels.Length);
		CreateSplashScreen(worker.SplashScreenModels[randomIndex]);
	}

	public static void SetWorker(SplashScreenManagerWorker worker) {
		SplashScreenManager.worker = worker;
	}

	private static void CreateSplashScreen(SplashScreen splashScreenModel) {
		SplashScreen splashScreen = (SplashScreen) Object.Instantiate(splashScreenModel);
		
		GameObject background = new GameObject("Background"); // TODO: use ConfigurationManager
		background.transform.parent = splashScreen.transform;
		SpriteRenderer spriteRenderer = background.AddComponent<SpriteRenderer>();
		spriteRenderer.sortingLayerName = ConfigurationManager.SortingLayerBackground;
		spriteRenderer.sortingOrder = 0; // TODO: use constant?
		spriteRenderer.sprite = splashScreen.Background;
	}

}
