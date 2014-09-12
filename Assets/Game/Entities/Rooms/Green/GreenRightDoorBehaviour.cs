using SaguFramework;

namespace EmergenciaQuimica {
	
	public class GreenRightDoorBehaviour : RoomTriggerBehaviour {

		public override void OnCharacterEnter(Character character) {
			if (character.GetId() == State.GetPlayerCharacterId())
				Game.ChangeRoom("Laboratory", "LeftDoor");
		}

		protected override string GetTooltip() {
			return Language.GetText("GreenRightDoorTooltip");
		}

	}
	
}
