using SaguFramework;

namespace EmergenciaQuimica {
	
	public class LaboratoryLeftDoorBehaviour : TriggerBehaviour {
		
		public override void OnLook() {}
		
		public override void OnPlayerCharacterEnter() {}

		protected override string GetDescription() {
			return "Salir del laboratorio"; // TODO
		}

	}
	
}
