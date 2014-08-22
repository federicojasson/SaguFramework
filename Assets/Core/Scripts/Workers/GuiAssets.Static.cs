using UnityEngine;

public partial class GuiAssets : MonoBehaviour {
	
	private static GuiAssets instance; // Singleton instance

	public static Menu CreateMenu(string id) {
		// Gets the menu prefab
		Menu menuPrefab = instance.MenuPrefabs[id];

		// Instantiates the menu prefab
		Menu menu = UtilityManager.Instantiate<Menu>(menuPrefab);
		
		// Creates a game object that shows the image
		//UtilityManager.CreateImageObject(menu.transform, menu.Image, Parameters.MenuImageSortingLayer);
		
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

	public static Sprite GetDefaultFadeSprite() {
		return instance.DefaultFadeSprite;
	}
	
	private static SplashScreen CreateSplashScreen(SplashScreen splashScreenPrefab) {
		// Instantiates the splash screen prefab
		SplashScreen splashScreen = UtilityManager.Instantiate<SplashScreen>(splashScreenPrefab);
		
		// Creates a game object that shows the image
		//UtilityManager.CreateImageObject(splashScreen.transform, splashScreen.Image, Parameters.SplashScreenImageSortingLayer);
		
		return splashScreen;
	}
	
}
