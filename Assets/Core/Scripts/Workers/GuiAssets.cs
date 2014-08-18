using UnityEngine;

public partial class GuiAssets : MonoBehaviour {

	public Texture2D DefaultFadeInTexture;
	public Texture2D DefaultFadeOutTexture;
	public SplashScreen MainSplashScreenPrefab;
	public MenuMap MenuPrefabs;
	public SplashScreen[] RoomSplashScreenPrefabs;

	public void Awake() {
		instance = this;
	}

}
