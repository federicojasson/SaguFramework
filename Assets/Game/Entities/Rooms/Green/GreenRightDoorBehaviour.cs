using SaguFramework;

namespace EmergenciaQuimica {
	
	public sealed class GreenRightDoorBehaviour : RoomTriggerBehaviour {

		public override void OnCharacterEnter(Character character) {
			Game.TryChangeRoom(character, "Laboratory", "LeftDoor");
		}
		
		public override void OnLook() {
			Game.LookAndDescribe(GetEntity(), "GreenRightDoorDescription");
		}
		
		public override void OnPickUp() {
			Game.LookAndNegate(GetEntity());
		}
		
		public override void OnSpeak() {
			Game.LookAndNegate(GetEntity());
		}
		
		public override void OnUseInventoryItem(InventoryItem inventoryItem) {
			Game.LookAndNegate(GetEntity());
		}

		protected override string GetTooltip() {
			return Framework.GetText("GreenRightDoorTooltip");
		}

	}
	
}
