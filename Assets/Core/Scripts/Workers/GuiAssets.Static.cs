using UnityEngine;

public partial class GuiAssets : MonoBehaviour {
	
	private static GuiAssets instance; // Singleton instance

	public static void DestroyMenu(Menu menu) {
		Destroy(menu);
	}

	public static FadeParameters GetDefaultFadeParameters() {
		return instance.DefaultFadeParameters;
	}

	public static Menu InstantiateMenu(string id) {
		// Gets the menu prefab
		Menu menuPrefab = instance.MenuPrefabs[id];

		// Clones the menu prefab
		Menu menu = (Menu) Object.Instantiate(menuPrefab);
		
		// Instantiates a game object that shows the background
		GameObject background = new GameObject("Background"); // TODO: use Parameters?
		background.transform.parent = menu.transform;
		SpriteRenderer spriteRenderer = background.AddComponent<SpriteRenderer>();
		spriteRenderer.sortingLayerName = Parameters.MenuBackgroundSortingLayer;
		spriteRenderer.sortingOrder = 0; // TODO: use Parameters?
		spriteRenderer.sprite = menu.Background;
		
		return menu;
	}

	public static SplashScreen InstantiateSplashScreen(string id) {
		// Gets the splash screen prefab
		SplashScreen splashScreenPrefab = instance.SplashScreenPrefabs[id];

		// Instantiates the splash screen
		return InstantiateSplashScreen(splashScreenPrefab);
	}
	
	public static SplashScreen InstantiateSplashScreenFromGroup(string id) {
		// Gets the splash screen prefab group
		SplashScreen[] splashScreenPrefabGroup = instance.SplashScreenPrefabGroups[id];

		// Selects a random splash screen prefab from the group
		int randomIndex = Random.Range(0, splashScreenPrefabGroup.Length);
		SplashScreen splashScreenPrefab = splashScreenPrefabGroup[randomIndex];
		
		// Instantiates the splash screen
		return InstantiateSplashScreen(splashScreenPrefab);
	}
	
	private static SplashScreen InstantiateSplashScreen(SplashScreen splashScreenPrefab) {
		// Clones the splash screen prefab
		SplashScreen splashScreen = (SplashScreen) Object.Instantiate(splashScreenPrefab);
		
		// Instantiates a game object that shows the background
		GameObject background = new GameObject("Background"); // TODO: use Parameters?
		background.transform.parent = splashScreen.transform;
		SpriteRenderer spriteRenderer = background.AddComponent<SpriteRenderer>();
		spriteRenderer.sortingLayerName = Parameters.SplashScreenBackgroundSortingLayer;
		spriteRenderer.sortingOrder = 0; // TODO: use Parameters?
		spriteRenderer.sprite = splashScreen.Background;
		
		return splashScreen;
	}
	
}
