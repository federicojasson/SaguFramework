using UnityEngine;

public partial class GuiAssets : MonoBehaviour {
	
	private static GuiAssets instance; // Singleton instance

	public static SplashScreen CreateSplashScreen(string id) {
		// Gets the splash screen prefab
		SplashScreen splashScreenPrefab = instance.SplashScreenPrefabs[id];

		// Creates the splash screen
		return CreateSplashScreen(splashScreenPrefab);
	}
	
	public static SplashScreen CreateSplashScreenFromGroup(string id) {
		// Gets the splash screen prefab group
		SplashScreen[] splashScreenPrefabGroup = instance.SplashScreenPrefabGroups[id];

		// Selects a random splash screen prefab from the group
		int randomIndex = Random.Range(0, splashScreenPrefabGroup.Length);
		SplashScreen splashScreenPrefab = splashScreenPrefabGroup[randomIndex];
		
		// Creates the splash screen
		return CreateSplashScreen(splashScreenPrefab);
	}
	
	public static FadeInformation GetDefaultFadeInformation() {
		return instance.DefaultFadeInformation;
	}
	
	private static SplashScreen CreateSplashScreen(SplashScreen splashScreenPrefab) {
		// Clones the splash screen prefab
		SplashScreen splashScreen = (SplashScreen) Object.Instantiate(splashScreenPrefab);
		
		// Creates a game object that shows the background
		GameObject background = new GameObject("Background"); // TODO: use Parameters?
		background.transform.parent = splashScreen.transform;
		SpriteRenderer spriteRenderer = background.AddComponent<SpriteRenderer>();
		spriteRenderer.sortingLayerName = Parameters.SortingLayerSplashScreenBackground;
		spriteRenderer.sortingOrder = 0; // TODO: use Parameters?
		spriteRenderer.sprite = splashScreen.Background;
		
		return splashScreen;
	}
	
}
