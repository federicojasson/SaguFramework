using UnityEngine;

public partial class GuiAssets : MonoBehaviour {

	public FadeParameters DefaultFadeParameters;
	public MenuMap MenuPrefabs;
	public SplashScreenArrayMap SplashScreenPrefabGroups;
	public SplashScreenMap SplashScreenPrefabs;

	public void Awake() {
		instance = this;
	}

}
