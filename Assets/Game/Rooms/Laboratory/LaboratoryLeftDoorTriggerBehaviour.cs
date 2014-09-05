using SaguFramework;

namespace EmergenciaQuimica {
	
	public class LaboratoryLeftDoorTriggerBehaviour : TriggerBehaviour {
		
		public override void OnPlayerCharacterEnter() {
			// TODO: LaboratoryLeftDoorTrigger.OnPlayerCharacterEnter()
			UnityEngine.Debug.Log("LaboratoryLeftDoorTrigger.OnPlayerCharacterEnter()");
		}

		public override void OnPlayerCharacterExit() {
			// TODO: LaboratoryLeftDoorTrigger.OnPlayerCharacterExit()
			UnityEngine.Debug.Log("LaboratoryLeftDoorTrigger.OnPlayerCharacterExit()");
		}
		
	}
	
}
