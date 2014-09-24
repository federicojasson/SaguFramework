namespace SaguFramework {

	/// The behaviour of an inventory item.
	/// All game's inventory items must inherit from this class.
	public abstract class InventoryItemBehaviour : EntityBehaviour {
		
		public override sealed void OnCharacterEnter(Character character) {}

		public override sealed void OnClick() {
			// Selects the associated inventory item
			InputReader.SelectInventoryItem((InventoryItem) GetEntity());
		}

		public override sealed void OnDefocus() {
			// Clears the tooltip
			Drawer.ClearTooltip();
		}
		
		public override sealed void OnFocus() {
			// Sets the tooltip
			Drawer.SetTooltip(GetTooltip());
		}
		
		public override sealed void OnPickUp() {}
		
		public override sealed void OnShowGui() {}
		
		public override sealed void OnSpeak() {}
		
		public override sealed void OnWalk(float x) {}
		
		/// Returns the inventory item's tooltip.
		protected virtual string GetTooltip() {
			// By default, the tooltip is empty (so it won't show)
			return string.Empty;
		}

	}
	
}
