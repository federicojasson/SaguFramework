using UnityEngine;

public partial class GuiAssets : MonoBehaviour {
	
	private static GuiAssets instance; // Singleton instance
	
	public static SplashScreen CreateMainSplashScreen() {
		// Creates the main splash screen
		return CreateSplashScreen(instance.MainSplashScreenPrefab);
	}
	
	public static SplashScreen CreateRandomRoomSplashScreen() {
		// Selects a room splash screen prefab randomly
		int randomIndex = Random.Range(0, instance.RoomSplashScreenPrefabs.Length);
		SplashScreen splashScreenPrefab = instance.RoomSplashScreenPrefabs[randomIndex];
		
		// Creates the room splash screen
		return CreateSplashScreen(splashScreenPrefab);
	}
	
	public static Texture2D GetDefaultFadeInTexture() {
		return instance.DefaultFadeInTexture;
	}

	public static Texture2D GetDefaultFadeOutTexture() {
		return instance.DefaultFadeOutTexture;
	}
	
	private static SplashScreen CreateSplashScreen(SplashScreen splashScreenPrefab) {
		// Clones the splash screen prefab
		SplashScreen splashScreen = (SplashScreen) Object.Instantiate(splashScreenPrefab);
		
		// Creates a game object that shows the background
		GameObject background = new GameObject("Background"); // TODO: use Parameters
		background.transform.parent = splashScreen.transform;
		SpriteRenderer spriteRenderer = background.AddComponent<SpriteRenderer>();
		spriteRenderer.sortingLayerName = "Background"; // TODO: use Parameters
		spriteRenderer.sortingOrder = 0; // TODO: use Parameters
		spriteRenderer.sprite = splashScreen.Background;
		
		return splashScreen;
	}
	
}
