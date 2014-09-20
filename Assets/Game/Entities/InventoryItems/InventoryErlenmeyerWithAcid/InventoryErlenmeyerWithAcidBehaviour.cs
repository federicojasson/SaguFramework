using SaguFramework;

namespace EmergenciaQuimica {
	
	public sealed class InventoryErlenmeyerWithAcidBehaviour : InventoryItemBehaviour {

		public override void OnLook() {
			Game.Describe("ErlenmeyerWithAcidDescription");
		}
		
		public override void OnUseInventoryItem(InventoryItem inventoryItem) {
			Game.Negate();
		}
		
		protected override string GetTooltip() {
			return Framework.GetText("ErlenmeyerWithAcidTooltip");
		}

	}
	
}
