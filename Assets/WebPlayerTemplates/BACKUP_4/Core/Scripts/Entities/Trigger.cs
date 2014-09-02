using UnityEngine;

namespace SaguFramework {
	
	public class Trigger : MonoBehaviour {
		
		private TriggerBehaviour behaviour;

		public void OnTriggerEnter() {
			behaviour.OnTriggerActivated();
		}

		public void SetBehaviour(TriggerBehaviour behaviour) {
			this.behaviour = behaviour;
		}

	}
	
}
