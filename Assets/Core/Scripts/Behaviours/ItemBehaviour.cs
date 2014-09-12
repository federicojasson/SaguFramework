﻿namespace SaguFramework {
	
	public abstract class ItemBehaviour : EntityBehaviour {

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
