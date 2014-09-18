namespace SaguFramework {
	
	public abstract class InventoryItemBehaviour : EntityBehaviour {
		
		public override sealed void OnCharacterEnter(Character character) {}

		public override sealed void OnClick() {
			OrderHandler.SelectInventoryItem((InventoryItem) GetEntity());
		}

		public override sealed void OnDefocus() {
			GraphicHandler.ClearTooltip();
		}
		
		public override sealed void OnFocus() {
			GraphicHandler.SetTooltip(GetTooltip());
		}
		
		public override sealed void OnPickUp() {}
		
		public override sealed void OnShowGui() {}
		
		public override sealed void OnSpeak() {}
		
		public override sealed void OnWalk(float x) {}
		
		protected virtual string GetTooltip() {
			return string.Empty;
		}

	}
	
}
