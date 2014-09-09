namespace SaguFramework {
	
	public class OrderHandler : Worker {

		private static Order order;
		private static int orderIndex;
		private static Order[][] orderSets;
		private static InventoryItem selectedInventoryItem;

		static OrderHandler() {
			order = Order.None;
			NotifyOrderChange();

			int gameModeCount = Utilities.GetEnumCount(typeof(GameMode));
			orderSets = new Order[gameModeCount][];

			orderSets[(int) GameMode.Inventory] = new Order[] {
				Order.Click,
				Order.Look
			};

			orderSets[(int) GameMode.Menu] = new Order[] {
				Order.Click
			};

			orderSets[(int) GameMode.Playing] = new Order[] {
				Order.Look,
				Order.PickUp,
				Order.Speak,
				Order.Walk
			};

			orderSets[(int) GameMode.UsingInventoryItem] = new Order[] {};

			orderSets[(int) GameMode.Waiting] = new Order[] {
				Order.None
			};
		}

		public static Order GetOrder() {
			return order;
		}

		public static InventoryItem GetSelectedInventoryItem() {
			return selectedInventoryItem;
		}
		
		private static void NotifyOrderChange() {
			foreach (Worker worker in Objects.GetWorkers())
				worker.OnOrderChange();
		}

		public virtual void OnGameModeChange() {
			GameMode gameMode = GameHandler.GetGameMode();

			if (gameMode == GameMode.UsingInventoryItem)
				return;

			Order[] orderSet = orderSets[(int) gameMode];
			int index = Utilities.SearchArray<Order>(orderSet, order);
			if (index > 0)
				orderIndex = index;
			else {
				orderIndex = 0;
				order = orderSet[0];
				NotifyOrderChange();
			}
		}

	}
	
}
