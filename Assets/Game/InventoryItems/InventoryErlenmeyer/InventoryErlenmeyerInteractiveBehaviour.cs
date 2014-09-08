using SaguFramework;

namespace EmergenciaQuimica {
	
	public class InventoryErlenmeyerInteractiveBehaviour : InventoryItemInteractiveBehaviour {
		
		public override void OnCursorEnter() {
			Game.SetTooltip("Erlenmeyer");
		}
		
		public override void OnCursorExit() {
			Game.ClearTooltip();
		}
		
	}
	
}
