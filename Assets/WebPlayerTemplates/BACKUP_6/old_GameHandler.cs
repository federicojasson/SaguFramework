namespace SaguFramework {
	
	public class old_GameHandler : old_Worker {

		/*private static bool gameLocked;
		private static GameMode gameMode;

		static old_GameHandler() {
			gameLocked = false;
			SetGameMode(GameMode.Waiting);
		}

		public static GameMode GetGameMode() {
			return gameMode;
		}

		public static void LockGame() {
			gameLocked = true;
			UpdateGameMode();
		}
		
		public static void UnlockGame() {
			gameLocked = false;
			UpdateGameMode();
		}
		
		public static void UpdateGameMode() {
			if (gameLocked) {
				SetGameMode(GameMode.Waiting);
				return;
			}

			if (Objects.GetMenus().Count > 0) {
				SetGameMode(GameMode.Menu);
				return;
			}
			
			if (OrderHandler.GetOrder() == Order.UseInventoryItem) {
				SetGameMode(GameMode.UsingInventoryItem);
				return;
			}
			
			Inventory inventory = Objects.GetInventory();
			if (inventory != null && inventory.IsActivated()) {
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
		}*/

	}
	
}
