namespace SaguFramework {
	
	public abstract class InventoryItemBehaviour : EntityBehaviour {

		public override void OnDefocus() {
			GraphicHandler.ClearTooltip();
		}
		
		public override void OnFocus() {
			GraphicHandler.SetTooltip(GetTooltip());
		}
		
		protected abstract string GetTooltip();

	}
	
}
