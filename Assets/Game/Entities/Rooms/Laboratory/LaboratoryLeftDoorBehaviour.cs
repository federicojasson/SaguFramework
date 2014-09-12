using SaguFramework;

namespace EmergenciaQuimica {
	
	public class LaboratoryLeftDoorBehaviour : RoomTriggerBehaviour {

		public override void OnCharacterEnter(Character character) {
			if (character.GetId() == State.GetPlayerCharacterId())
				Game.ChangeRoom("Green", "RightDoor");
		}

		protected override string GetTooltip() {
			return Language.GetText("LaboratoryLeftDoorTooltip");
		}

	}
	
}
