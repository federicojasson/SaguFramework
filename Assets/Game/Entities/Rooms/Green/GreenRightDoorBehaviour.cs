using SaguFramework;

namespace EmergenciaQuimica {
	
	public class GreenRightDoorBehaviour : RoomTriggerBehaviour {

		public override void OnCharacterEnter(Character character) {
			if (character.GetId() == "Scientist")
				Game.ChangeRoom("Laboratory", "LeftDoor", "Molecules");
		}

		protected override string GetTooltip() {
			return Language.GetText("GreenRightDoorTooltip");
		}

	}
	
}
