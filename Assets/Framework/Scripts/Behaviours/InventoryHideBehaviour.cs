namespace SaguFramework {
	
	/// The behaviour of the inventory's hide trigger.
	public sealed class InventoryHideBehaviour : InventoryTriggerBehaviour {

		public override void OnClick() {
			// Toggles the inventory
			InventoryManager.ToggleInventory();
		}

		public override void OnUseInventoryItem(InventoryItem inventoryItem) {
			// Toggles the inventory
			InventoryManager.ToggleInventory();
		}
		
	}
	
}
