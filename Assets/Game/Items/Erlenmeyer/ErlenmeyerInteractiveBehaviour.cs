using SaguFramework;

namespace EmergenciaQuimica {
	
	public class ErlenmeyerInteractiveBehaviour : InteractiveBehaviour {
		
		public override void OnCursorEnter() {
			Game.SetTooltip("Erlenmeyer");
		}

		public override void OnCursorExit() {
			Game.ClearTooltip();
		}
		
	}
	
}
