using UnityEngine;

namespace SaguFramework {
	
	public class InteractiveEntity : MonoBehaviour {
		
		private InteractiveEntityBehaviour behaviour;

		public void OnMouseEnter() {
			behaviour.OnCursorEnter();
		}
		
		public void OnMouseExit() {
			behaviour.OnCursorExit();
		}
		
		public void SetBehaviour(InteractiveEntityBehaviour behaviour) {
			this.behaviour = behaviour;
		}
		
	}
	
}
