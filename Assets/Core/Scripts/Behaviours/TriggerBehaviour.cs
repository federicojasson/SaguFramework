using UnityEngine;

namespace SaguFramework {
	
	public abstract class TriggerBehaviour : EntityBehaviour {
		
		public override void OnDefocus() {
			ScreenHandler.ClearTooltip();
		}
		
		public override void OnFocus() {
			ScreenHandler.SetTooltip(GetDescription());
		}

		public override void OnWalk(Vector2 position) {
			// TODO: caminar a la posicion
		}
		
		protected abstract string GetDescription();
		
	}
	
}
