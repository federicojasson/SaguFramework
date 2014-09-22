namespace SaguFramework {

	// TODO: comentar

	public sealed class InventoryHideBehaviour : InventoryTriggerBehaviour {

		public override void OnClick() {
			InventoryManager.ToggleInventory();
		}

		public override void OnUseInventoryItem(InventoryItem inventoryItem) {
			InventoryManager.ToggleInventory();
		}
		
	}
	
}
