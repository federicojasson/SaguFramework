namespace SaguFramework {
	
	public abstract class InventoryItemBehaviour : EntityBehaviour {

		public override void OnDefocus() {
			ScreenHandler.ClearTooltip();
		}
		
		public override void OnFocus() {
			ScreenHandler.SetTooltip(GetDescription());
		}
		
		protected abstract string GetDescription();

	}
	
}
