namespace SaguFramework {
	
	public class InventoryHandler : Worker {

		private static InventoryHandler instance;
		
		public static InventoryHandler GetInstance() {
			return instance;
		}
		
		public override void Awake() {
			base.Awake();
			instance = this;
		}

		public void HideInventory() {
			foreach (InventoryItem inventoryItem in Objects.GetInventoryItems())
				; // TODO

			Objects.GetInventory().Hide();
		}

		public void ShowInventory() {
			Objects.GetInventory().Show();

			foreach (InventoryItem inventoryItem in Objects.GetInventoryItems())
				; // TODO
		}

	}
	
}
