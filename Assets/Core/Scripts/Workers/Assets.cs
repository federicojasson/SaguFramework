using SaguFramework.Structures.Serializable;
using UnityEngine;

namespace SaguFramework.Workers {

	public partial class Assets : MonoBehaviour {

		public CharacterParametersMap CharacterParameters;
		public float GameAspectRatio;
		public InventoryItemParametersMap InventoryItemParameters;
		public InventoryParameters InventoryParameters;
		public ItemParametersMap ItemParameters;
		public MainMenuParameters MainMenuParameters;
		public SplashScreenParameters MainSplashScreenParameters;
		public MenuParametersMap MenuParameters;
		public RoomParametersMap RoomParameters;
		public SplashScreenParameters[] SplashScreensParameters;

		public void Awake() {
			// Sets itself as the singleton instance
			instance = this;
		}

	}

}
