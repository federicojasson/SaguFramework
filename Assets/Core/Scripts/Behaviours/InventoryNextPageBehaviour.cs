namespace SaguFramework {
	
	public sealed class InventoryNextPageBehaviour : InventoryTriggerBehaviour {

		public override void OnClick() {
			InventoryManager.ShowNextPage();
		}
		
		public override void OnLook() {
			InventoryManager.ShowNextPage();
		}
		
		public override void OnUseInventoryItem(InventoryItem inventoryItem) {
			InventoryManager.ShowNextPage();
		}
		
	}
	
}
