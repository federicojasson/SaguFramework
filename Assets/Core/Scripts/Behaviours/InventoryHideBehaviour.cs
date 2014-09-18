namespace SaguFramework {
	
	public sealed class InventoryHideBehaviour : InventoryTriggerBehaviour {

		public override void OnClick() {
			if (GameHandler.GetGameMode() == GameMode.UsingInventoryItem)
				InventoryHandler.ToggleInventory();
		}
		
	}
	
}
