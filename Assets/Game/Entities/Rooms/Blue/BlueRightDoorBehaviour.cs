using SaguFramework;

namespace EmergenciaQuimica {
	
	public sealed class BlueRightDoorBehaviour : RoomTriggerBehaviour {
		
		public override void OnCharacterEnter(Character character) {
			Game.TryChangeRoom(character, "Green", "LeftDoor");
		}
		
		public override void OnLook() {
			Game.LookAndDescribe(GetEntity(), "BlueRightDoorDescription");
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
			return Framework.GetText("BlueRightDoorTooltip");
		}
	
	}
	
}
