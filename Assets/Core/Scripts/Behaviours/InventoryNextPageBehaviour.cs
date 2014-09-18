namespace SaguFramework {
	
	public sealed class InventoryNextPageBehaviour : InventoryTriggerBehaviour {

		public override void OnClick() {
			InventoryHandler.ShowNextPage();
		}
		
		public override void OnLook() {
			InventoryHandler.ShowNextPage();
		}
		
		public override void OnUseInventoryItem(InventoryItem inventoryItem) {
			InventoryHandler.ShowNextPage();
		}
		
	}
	
}
