using SaguFramework;

namespace EmergenciaQuimica {
	
	public class GreenLeftDoorBehaviour : RoomTriggerBehaviour {

		public override void OnCharacterEnter(Character character) {
			if (character.GetId() == "Scientist")
				Game.ChangeRoom("Blue", "RightDoor", "Molecules");
		}

		protected override string GetTooltip() {
			return Language.GetText("GreenLeftDoorTooltip");
		}
	
	}
	
}
