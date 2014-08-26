using UnityEngine;

namespace FrameworkNamespace {

	public partial class FrameworkAssets : MonoBehaviour {
		
		private static FrameworkAssets instance; // Singleton instance

		public static GameImage CreateGameImage() {
			// Instantiates the game image prefab
			return UtilityManager.Instantiate<GameImage>(instance.GameImagePrefab);
		}
		
	}

}
