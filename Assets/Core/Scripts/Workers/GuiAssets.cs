using UnityEngine;

public partial class GuiAssets : MonoBehaviour {

	public Texture2D DefaultFadeTexture;
	public MenuMap MenuPrefabs;
	public SplashScreenArrayMap SplashScreenPrefabGroups;
	public SplashScreenMap SplashScreenPrefabs;

	public void Awake() {
		instance = this;
	}

}
