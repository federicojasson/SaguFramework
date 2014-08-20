using UnityEngine;

public partial class GuiAssets : MonoBehaviour {
	
	private static GuiAssets instance; // Singleton instance

	public static Menu CreateMenu(string id) {
		// Gets the menu prefab
		Menu menuPrefab = instance.MenuPrefabs[id];

		// Instantiates the menu prefab
		Menu menu = UtilityManager.Instantiate<Menu>(menuPrefab);
		
		// Creates a game object that shows the background
		GameObject background = new GameObject("Background"); // TODO: use Parameters?
		background.transform.parent = menu.transform;
		SpriteRenderer backgroundSpriteRenderer = background.AddComponent<SpriteRenderer>();
		backgroundSpriteRenderer.sortingLayerName = Parameters.MenuBackgroundSortingLayer;
		backgroundSpriteRenderer.sortingOrder = 0; // TODO: use Parameters?
		backgroundSpriteRenderer.sprite = menu.Background;
		
		return menu;
	}

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

	public static void DestroyMenu(Menu menu) {
		UtilityManager.Destroy(menu.gameObject);
	}

	public static FadeParameters GetDefaultFadeParameters() {
		return instance.DefaultFadeParameters;
	}
	
	private static SplashScreen CreateSplashScreen(SplashScreen splashScreenPrefab) {
		// Instantiates the splash screen prefab
		SplashScreen splashScreen = UtilityManager.Instantiate<SplashScreen>(splashScreenPrefab);
		
		// Creates a game object that shows the background
		GameObject background = new GameObject("Background"); // TODO: use Parameters?
		background.transform.parent = splashScreen.transform;
		SpriteRenderer backgroundSpriteRenderer = background.AddComponent<SpriteRenderer>();
		backgroundSpriteRenderer.sortingLayerName = Parameters.SplashScreenBackgroundSortingLayer;
		backgroundSpriteRenderer.sortingOrder = 0; // TODO: use Parameters?
		backgroundSpriteRenderer.sprite = splashScreen.Background;
		
		return splashScreen;
	}
	
}
