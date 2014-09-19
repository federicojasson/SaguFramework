namespace SaguFramework {
	
	public class old_OrderHandler : old_Worker {

		/*private static Order order;
		private static int orderIndex;
		private static Order[] orderSet;
		private static Order[][] orderSets;
		private static InventoryItem selectedInventoryItem;

		static old_OrderHandler() {
			SetOrder(Order.None);

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
				Order.Walk,
				Order.Look,
				Order.PickUp,
				Order.Speak
			};

			orderSets[(int) GameMode.UsingInventoryItem] = new Order[] {};

			orderSets[(int) GameMode.Waiting] = new Order[] {
				Order.None
			};

			orderSet = orderSets[(int) GameMode.Waiting];
			orderIndex = 0;
		}

		public static Order GetOrder() {
			return order;
		}

		public static InventoryItem GetSelectedInventoryItem() {
			return selectedInventoryItem;
		}

		public static void SelectInventoryItem(InventoryItem inventoryItem) {
			selectedInventoryItem = inventoryItem;
			UnityEngine.Debug.Log("Selected: " + inventoryItem.GetId());
			SetOrder(Order.UseInventoryItem);
		}

		public static void SetNextOrder() {
			orderIndex = (orderIndex + 1) % orderSet.Length;
			SetOrder(orderSet[orderIndex]);
		}

		public static void SetPreviousOrder() {
			orderIndex = (orderIndex - 1 + orderSet.Length) % orderSet.Length;
			SetOrder(orderSet[orderIndex]);
		}

		public static void UnselectInventoryItem() {
			selectedInventoryItem = null;
			UnityEngine.Debug.Log("Unselected");
			SetOrder(Order.None);
		}
		
		private static void SetOrder(Order order) {
			if (OrderHandler.order != order) {
				OrderHandler.order = order;
				
				UnityEngine.Debug.Log("Order: " + order);

				foreach (Worker worker in Objects.GetWorkers())
					worker.OnOrderChange();
			}
		}

		public override void OnGameModeChange() {
			GameMode gameMode = GameHandler.GetGameMode();
			orderSet = orderSets[(int) gameMode];

			if (gameMode == GameMode.UsingInventoryItem)
				return;

			int index = Utilities.SearchArray<Order>(orderSet, order);
			if (index > 0)
				orderIndex = index;
			else {
				orderIndex = 0;
				SetOrder(orderSet[orderIndex]);
			}
		}*/

	}
	
}
