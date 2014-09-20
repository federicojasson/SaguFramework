using SaguFramework;

namespace EmergenciaQuimica {
	
	public sealed class ProtectionSuitBehaviour : ItemBehaviour {
		
		public override void OnLook() {
			Game.LookAndDescribe(GetEntity(), "ProtectionSuitDescription");
		}

		public override void OnPickUp() {
			Game.PickUp(GetEntity(), "ProtectionSuit", "InventoryProtectionSuit");
		}
		
		public override void OnSpeak() {
			Game.LookAndNegate(GetEntity());
		}
		
		public override void OnUseInventoryItem(InventoryItem inventoryItem) {
			Game.LookAndNegate(GetEntity());
		}
		
		protected override string GetTooltip() {
			return Framework.GetText("ProtectionSuitTooltip");
		}

	}
	
}
