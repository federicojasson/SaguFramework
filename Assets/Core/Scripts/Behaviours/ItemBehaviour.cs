namespace SaguFramework {
	
	public abstract class ItemBehaviour : EntityBehaviour {

		public override void OnDefocus() {
			ScreenHandler.ClearTooltip();
		}
		
		public override void OnFocus() {
			ScreenHandler.SetTooltip(GetDescription());
		}
		
		protected abstract string GetDescription();

	}
	
}
