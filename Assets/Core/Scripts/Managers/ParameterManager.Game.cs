using SaguFramework.Structures.Serializable;
using SaguFramework.Workers;

namespace SaguFramework.Managers {

	public static partial class ParameterManager {

		// TODO: usar esta clase para obtener parametros del juego

		public static CharacterParameters GetCharacterParameters(string characterId) {
			return Game.GetInstance().GameParameters.CharacterParameters[characterId];
		}

		public static float GetGameAspectRatio() {
			return Game.GetInstance().GameParameters.GameAspectRatio;
		}

		public static InventoryItemParameters GetInventoryItemParameters(string inventoryItemId) {
			return Game.GetInstance().GameParameters.InventoryItemParameters[inventoryItemId];
		}
		
		public static InventoryParameters GetInventoryParameters() {
			return Game.GetInstance().GameParameters.InventoryParameters;
		}

		public static ItemParameters GetItemParameters(string itemId) {
			return Game.GetInstance().GameParameters.ItemParameters[itemId];
		}

		public static MainMenuParameters GetMainMenuParameters() {
			return Game.GetInstance().GameParameters.MainMenuParameters;
		}
		
		public static SplashScreenParameters GetMainSplashScreenParameters() {
			return Game.GetInstance().GameParameters.MainSplashScreenParameters;
		}

		public static MenuParameters GetMenuParameters(string menuId) {
			return Game.GetInstance().GameParameters.MenuParameters[menuId];
		}

		public static RoomParameters GetRoomParameters(string roomId) {
			return Game.GetInstance().GameParameters.RoomParameters[roomId];
		}

		public static SplashScreenParameters[] GetSplashScreensParameters() {
			return Game.GetInstance().GameParameters.SplashScreensParameters;
		}

		public static string GetStateFilesDirectoryPath() {
			return Game.GetInstance().GameParameters.StateFilesDirectoryPath;
		}

	}

}
