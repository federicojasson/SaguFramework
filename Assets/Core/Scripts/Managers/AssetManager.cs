using SaguFramework.Structures.Serializable;
using SaguFramework.Workers;

namespace SaguFramework.Managers {

	public static class AssetManager {

		// TODO: usar esta clase para obtener parametros

		public static CharacterParameters GetCharacterParameters(string characterId) {
			return Assets.GetInstance().CharacterParameters[characterId];
		}

		public static float GetGameAspectRatio() {
			return Assets.GetInstance().GameAspectRatio;
		}

		public static InventoryItemParameters GetInventoryItemParameters(string inventoryItemId) {
			return Assets.GetInstance().InventoryItemParameters[inventoryItemId];
		}
		
		public static InventoryParameters GetInventoryParameters() {
			return Assets.GetInstance().InventoryParameters;
		}

		public static ItemParameters GetItemParameters(string itemId) {
			return Assets.GetInstance().ItemParameters[itemId];
		}

		public static MainMenuParameters GetMainMenuParameters() {
			return Assets.GetInstance().MainMenuParameters;
		}
		
		public static SplashScreenParameters GetMainSplashScreenParameters() {
			return Assets.GetInstance().MainSplashScreenParameters;
		}

		public static MenuParameters GetMenuParameters(string menuId) {
			return Assets.GetInstance().MenuParameters[menuId];
		}

		public static RoomParameters GetRoomParameters(string roomId) {
			return Assets.GetInstance().RoomParameters[roomId];
		}

		public static SplashScreenParameters[] GetSplashScreensParameters() {
			return Assets.GetInstance().SplashScreensParameters;
		}

	}

}
