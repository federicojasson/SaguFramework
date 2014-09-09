using SaguFramework;

namespace EmergenciaQuimica {
	
	public class GreenRightDoorBehaviour : RoomTriggerBehaviour {
		
		public override void OnCharacterEnter(Character character) {}
		
		public override void OnLook() {}

		protected override string GetDescription() {
			return "Entrar al laboratorio"; // TODO
		}

	}
	
}
