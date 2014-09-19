using SaguFramework;

namespace EmergenciaQuimica {
	
	public class GreenRightDoorBehaviour : RoomTriggerBehaviour {

		public override void OnCharacterEnter(Character character) {
			// TODO: refactor
			/*if (character.GetId() == "Scientist")
				Game.ChangeRoom("Laboratory", "LeftDoor", "Molecules");*/
		}
		
		public override void OnLook() {
			// TODO
		}
		
		public override void OnPickUp() {
			// TODO
		}
		
		public override void OnSpeak() {
			// TODO
		}
		
		public override void OnUseInventoryItem(InventoryItem inventoryItem) {
			// TODO
		}

		protected override string GetTooltip() {
			//return Language.GetText("GreenRightDoorTooltip");
			return string.Empty;
		}

	}
	
}
