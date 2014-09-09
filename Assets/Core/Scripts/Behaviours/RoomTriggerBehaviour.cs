using UnityEngine;

namespace SaguFramework {
	
	public abstract class RoomTriggerBehaviour : EntityBehaviour {
		
		public override void OnDefocus() {
			GraphicHandler.ClearTooltip();
		}
		
		public override void OnFocus() {
			GraphicHandler.SetTooltip(GetDescription());
		}

		public override void OnWalk(Vector2 position) {
			// TODO: caminar a la posicion
		}
		
		protected abstract string GetDescription();
		
	}
	
}
