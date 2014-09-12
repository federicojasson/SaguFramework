namespace SaguFramework {
	
	public class InventoryHideBehaviour : InventoryTriggerBehaviour {
		
		public override void OnFocus() {
			if (GameHandler.GetGameMode() == GameMode.UsingInventoryItem)
				InventoryHandler.ToggleInventory();
		}
		
	}
	
}
