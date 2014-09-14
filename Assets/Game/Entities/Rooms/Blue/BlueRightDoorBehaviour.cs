using SaguFramework;

namespace EmergenciaQuimica {
	
	public class BlueRightDoorBehaviour : RoomTriggerBehaviour {

		public override void OnCharacterEnter(Character character) {
			if (character.GetId() == "Scientist")
				Game.ChangeRoom("Green", "LeftDoor");
		}

		protected override string GetTooltip() {
			return Language.GetText("BlueRightDoorTooltip");
		}
	
	}
	
}
