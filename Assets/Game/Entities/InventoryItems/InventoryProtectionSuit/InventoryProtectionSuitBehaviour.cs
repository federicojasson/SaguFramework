using SaguFramework;

namespace EmergenciaQuimica {
	
	public sealed class InventoryProtectionSuitBehaviour : InventoryItemBehaviour {
		
		public override void OnLook() {
			Game.Describe("ProtectionSuitDescription");
		}
		
		public override void OnUseInventoryItem(InventoryItem inventoryItem) {
			Game.Negate();
		}

		protected override string GetTooltip() {
			return Framework.GetText("ProtectionSuitTooltip");
		}

	}
	
}
