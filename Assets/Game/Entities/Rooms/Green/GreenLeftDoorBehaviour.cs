using SaguFramework;

namespace EmergenciaQuimica {
	
	public sealed class GreenLeftDoorBehaviour : RoomTriggerBehaviour {

		public override void OnCharacterEnter(Character character) {
			Game.TryChangeRoom(character, "Blue", "RightDoor");
		}
		
		public override void OnLook() {
			Game.LookAndDescribe(GetEntity(), "GreenLeftDoorDescription");
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
			return Framework.GetText("GreenLeftDoorTooltip");
		}
	
	}
	
}
