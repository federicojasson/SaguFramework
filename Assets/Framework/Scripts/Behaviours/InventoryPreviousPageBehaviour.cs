namespace SaguFramework {
	
	/// The behaviour of the inventory previous page trigger.
	public sealed class InventoryPreviousPageBehaviour : InventoryTriggerBehaviour {
		
		public override void OnClick() {
			// Shows the inventory's previous page
			InventoryManager.ShowPreviousPage();
		}
		
		public override void OnLook() {
			// Shows the inventory's previous page
			InventoryManager.ShowPreviousPage();
		}
		
		public override void OnUseInventoryItem(InventoryItem inventoryItem) {
			// Shows the inventory's previous page
			InventoryManager.ShowPreviousPage();
		}
		
	}
	
}
