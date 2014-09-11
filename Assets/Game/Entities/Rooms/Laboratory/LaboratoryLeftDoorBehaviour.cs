using SaguFramework;

namespace EmergenciaQuimica {
	
	public class LaboratoryLeftDoorBehaviour : RoomTriggerBehaviour {
		
		public override void OnCharacterEnter(Character character) {}
		
		public override void OnLook() {}

		protected override string GetTooltip() {
			return "Salir del laboratorio"; // TODO
		}

	}
	
}
