namespace SaguFramework {
	
	public sealed class InventoryPreviousPageBehaviour : InventoryTriggerBehaviour {
		
		public override void OnClick() {
			InventoryHandler.ShowPreviousPage();
		}
		
		public override void OnLook() {
			InventoryHandler.ShowPreviousPage();
		}
		
		public override void OnUseInventoryItem(InventoryItem inventoryItem) {
			InventoryHandler.ShowPreviousPage();
		}
		
	}
	
}
