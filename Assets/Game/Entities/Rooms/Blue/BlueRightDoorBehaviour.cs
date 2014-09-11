using SaguFramework;

namespace EmergenciaQuimica {
	
	public class BlueRightDoorBehaviour : RoomTriggerBehaviour {
		
		public override void OnCharacterEnter(Character character) {}
		
		public override void OnLook() {}
		
		protected override string GetTooltip() {
			return "Ir a la habitacion verde"; // TODO
		}
	
	}
	
}
