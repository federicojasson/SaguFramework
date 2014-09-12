namespace SaguFramework {
	
	public class GameHandler : Worker {
		
		private static GameMode gameMode;

		static GameHandler() {
			SetGameMode(GameMode.Waiting);
		}

		public static GameMode GetGameMode() {
			return gameMode;
		}
		
		public static void UpdateGameMode() {
			if (Objects.GetMenus().Count > 0) {
				SetGameMode(GameMode.Menu);
				return;
			}
			
			if (OrderHandler.GetOrder() == Order.UseInventoryItem) {
				SetGameMode(GameMode.UsingInventoryItem);
				return;
			}
			
			Inventory inventory = Objects.GetInventory();
			if (inventory != null && inventory.IsShowing()) {
				SetGameMode(GameMode.Inventory);
				return;
			}
			
			if (Objects.GetRoom() != null) {
				SetGameMode(GameMode.Playing);
				return;
			}
			
			SetGameMode(GameMode.Waiting);
		}

		private static void SetGameMode(GameMode gameMode) {
			if (GameHandler.gameMode != gameMode) {
				GameHandler.gameMode = gameMode;

				UnityEngine.Debug.Log("GameMode: " + gameMode);

				foreach (Worker worker in Objects.GetWorkers())
					worker.OnGameModeChange();
			}
		}
		
		public void OnLevelWasLoaded(int level) {
			UpdateGameMode();
		}
		
		public override void OnOrderChange() {
			UpdateGameMode();
		}

	}
	
}
