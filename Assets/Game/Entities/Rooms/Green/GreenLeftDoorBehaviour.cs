using SaguFramework;

namespace EmergenciaQuimica {
	
	public class GreenLeftDoorBehaviour : RoomTriggerBehaviour {

		public override void OnCharacterEnter(Character character) {
			if (character.GetId() == State.GetPlayerCharacterId())
				Game.ChangeRoom("Blue", "RightDoor");
		}

		protected override string GetTooltip() {
			return Language.GetText("GreenLeftDoorTooltip");
		}
	
	}
	
}
