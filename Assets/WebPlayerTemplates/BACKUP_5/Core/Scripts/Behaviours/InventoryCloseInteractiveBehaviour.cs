namespace SaguFramework {
	
	public class InventoryCloseInteractiveBehaviour : InteractiveBehaviour {

		public override void OnCursorEnter() {
			if (InventoryHandler.GetInstance().GetSelectedItem() != null)
				Game.HideInventory();
		}

	}
	
}
