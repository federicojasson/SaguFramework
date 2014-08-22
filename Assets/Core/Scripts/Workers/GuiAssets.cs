using UnityEngine;

public partial class GuiAssets : MonoBehaviour {

	public Sprite DefaultFadeSprite;
	public MenuMap MenuPrefabs;
	public SplashScreenArrayMap SplashScreenPrefabGroups;
	public SplashScreenMap SplashScreenPrefabs;

	public void Awake() {
		instance = this;
	}

}
