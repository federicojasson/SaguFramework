namespace SaguFramework {
	
	/// The behaviour of the inventory next page trigger.
	public sealed class InventoryNextPageBehaviour : InventoryTriggerBehaviour {

		public override void OnClick() {
			// Shows the inventory's next page
			InventoryManager.ShowNextPage();
		}
		
		public override void OnLook() {
			// Shows the inventory's next page
			InventoryManager.ShowNextPage();
		}
		
		public override void OnUseInventoryItem(InventoryItem inventoryItem) {
			// Shows the inventory's next page
			InventoryManager.ShowNextPage();
		}
		
	}
	
}
