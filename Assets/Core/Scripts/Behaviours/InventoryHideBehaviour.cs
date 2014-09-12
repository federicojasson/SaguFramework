namespace SaguFramework {
	
	public class InventoryHideBehaviour : InventoryTriggerBehaviour {

		private bool wasDefocused;
		
		public override void OnDefocus() {
			wasDefocused = true;
		}
		
		public void OnEnable() {
			wasDefocused = false;
		}

		public override void OnFocus() {
			if (wasDefocused && GameHandler.GetGameMode() == GameMode.UsingInventoryItem)
				InventoryHandler.ToggleInventory();
		}
		
	}
	
}
