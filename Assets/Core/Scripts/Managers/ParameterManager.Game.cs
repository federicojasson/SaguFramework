using UnityEngine;

namespace SaguFramework {

	public static partial class ParameterManager {

		// TODO: usar esta clase para obtener parametros del juego

		public static Color GetCameraBackgroundColor() {
			return Game.GetInstance().GameParameters.CameraBackgroundColor;
		}

		public static CharacterParameters GetCharacterParameters(string characterId) {
			return Game.GetInstance().GameParameters.CharacterParameters[characterId];
		}

		public static float GetDelayBetweenSongs() {
			return Game.GetInstance().GameParameters.DelayBetweenSongs;
		}

		public static float GetGameAspectRatio() {
			return Game.GetInstance().GameParameters.GameAspectRatio;
		}
		
		public static string GetGameDirectoryPath() {
			return Game.GetInstance().GameParameters.GameDirectoryPath;
		}
		
		public static SplashScreenParameters GetGameSplashScreenParameters() {
			return Game.GetInstance().GameParameters.GameSplashScreenParameters;
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

		public static LoaderParameters GetMainLoaderParameters() {
			return Game.GetInstance().GameParameters.MainLoaderParameters;
		}
		
		public static LoaderParameters GetMainMenuLoaderParameters() {
			return Game.GetInstance().GameParameters.MainMenuLoaderParameters;
		}

		public static MenuParameters GetMainMenuParameters() {
			return Game.GetInstance().GameParameters.MainMenuParameters;
		}

		public static AudioClip GetMainSong() {
			return Game.GetInstance().GameParameters.MainSong;
		}

		public static AudioClip GetMainMenuSong() {
			return Game.GetInstance().GameParameters.MainMenuSong;
		}

		public static MenuParameters GetMenuParameters(string menuId) {
			return Game.GetInstance().GameParameters.MenuParameters[menuId];
		}
		
		public static LoaderParameters GetRoomLoaderParameters() {
			return Game.GetInstance().GameParameters.RoomLoaderParameters;
		}

		public static RoomParameters GetRoomParameters(string roomId) {
			return Game.GetInstance().GameParameters.RoomParameters[roomId];
		}

		public static AudioClip[] GetSongs() {
			return Game.GetInstance().GameParameters.Songs;
		}
		
		public static LoaderParameters GetSpecialLoaderParameters() {
			return Game.GetInstance().GameParameters.SpecialLoaderParameters;
		}
		
		public static LoaderParameters GetSplashScreenLoaderParameters() {
			return Game.GetInstance().GameParameters.SplashScreenLoaderParameters;
		}

		public static SplashScreenParameters[] GetSplashScreensParameters() {
			return Game.GetInstance().GameParameters.SplashScreensParameters;
		}

		public static bool ShuffleSongs() {
			return Game.GetInstance().GameParameters.ShuffleSongs;
		}

	}

}
