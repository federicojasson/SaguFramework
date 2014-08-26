using UnityEngine;

namespace FrameworkNamespace {

	public partial class GuiAssets : MonoBehaviour {

		public Texture2D DefaultFadeTexture;
		public MainMenuMap MainMenuPrefabs;
		public MenuMap MenuPrefabs;
		public SplashScreenArrayMap SplashScreenPrefabGroups;
		public SplashScreenMap SplashScreenPrefabs;

		public void Awake() {
			instance = this;
		}

	}

}
