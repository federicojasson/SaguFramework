namespace SaguFramework {

	// TODO: comentar

	public sealed class InventoryPreviousPageBehaviour : InventoryTriggerBehaviour {
		
		public override void OnClick() {
			InventoryManager.ShowPreviousPage();
		}
		
		public override void OnLook() {
			InventoryManager.ShowPreviousPage();
		}
		
		public override void OnUseInventoryItem(InventoryItem inventoryItem) {
			InventoryManager.ShowPreviousPage();
		}
		
	}
	
}
