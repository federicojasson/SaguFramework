namespace SaguFramework {
	
	public class InventoryHandler : Worker {

		private static InventoryHandler instance;
		
		public static InventoryHandler GetInstance() {
			return instance;
		}

		private InventoryItem selectedItem;
		
		public override void Awake() {
			base.Awake();
			instance = this;
		}

		public void HideInventory() {
			foreach (InventoryItem inventoryItem in Objects.GetInventoryItems())
				; // TODO

			Objects.GetInventory().Hide();
		}

		public void SelectItem(InventoryItem inventoryItem) {
			selectedItem = inventoryItem;
			InputHandler.GetInstance().SetInputMode(InputMode.UsingInventoryItem);
		}

		public void ShowInventory() {
			Objects.GetInventory().Show();

			foreach (InventoryItem inventoryItem in Objects.GetInventoryItems())
				; // TODO
		}

		public void UnselectItem() {
			selectedItem = null;
			InputHandler.GetInstance().SetCurrentInputMode();
		}

	}
	
}
