using UnityEngine;

public partial class GuiAssets : MonoBehaviour {

	public FadeParameters DefaultFadeInParameters;
	public FadeParameters DefaultFadeOutParameters;
	public MenuMap MenuPrefabs;
	public SplashScreenArrayMap SplashScreenPrefabGroups;
	public SplashScreenMap SplashScreenPrefabs;

	public void Awake() {
		instance = this;
	}

}
