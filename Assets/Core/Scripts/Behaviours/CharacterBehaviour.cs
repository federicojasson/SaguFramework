namespace SaguFramework {
	
	public abstract class CharacterBehaviour : EntityBehaviour {

		public override void OnDefocus() {
			GraphicHandler.ClearTooltip();
		}
		
		public override void OnFocus() {
			GraphicHandler.SetTooltip(GetTooltip());
		}
		
		protected abstract string GetTooltip();

	}
	
}
