namespace SaguFramework {
	
	public class GameHandler : Worker {
		
		private static GameMode gameMode;

		public static GameMode GetGameMode() {
			return gameMode;
		}

		private static void SetGameMode(GameMode gameMode) {
			GameHandler.gameMode = gameMode;

			foreach (Worker worker in Objects.GetWorkers())
				worker.OnGameModeChange();
		}
		
		public override void OnOrderChange() {
			if (OrderHandler.GetOrder() == Order.UseInventoryItem)
				SetGameMode(GameMode.UsingInventoryItem);
			else
				if (gameMode == GameMode.UsingInventoryItem) {
					if (Objects.GetInventory().IsShowing())
						SetGameMode(GameMode.Inventory);
					else
						SetGameMode(GameMode.Playing);
				}
		}

	}
	
}
