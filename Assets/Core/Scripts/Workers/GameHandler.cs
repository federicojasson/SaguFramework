namespace SaguFramework {
	
	public class GameHandler : Worker {
		
		private static GameMode gameMode;

		public static GameMode GetGameMode() {
			return gameMode;
		}

		public static void SetGameMode(GameMode gameMode) {
			GameHandler.gameMode = gameMode;
			NotifyGameModeChange();
		}

		private static void NotifyGameModeChange() {
			foreach (Worker worker in Objects.GetWorkers())
				worker.OnGameModeChange();
		}

	}
	
}
