namespace SaguFramework {
	
	public abstract class InventoryItemBehaviour : EntityBehaviour {

		public override void OnClick() {
			OrderHandler.SelectInventoryItem((InventoryItem) GetEntity());
		}

		public override void OnDefocus() {
			GraphicHandler.ClearTooltip();
		}
		
		public override void OnFocus() {
			GraphicHandler.SetTooltip(GetTooltip());
		}
		
		protected virtual string GetTooltip() {
			return string.Empty;
		}

	}
	
}
