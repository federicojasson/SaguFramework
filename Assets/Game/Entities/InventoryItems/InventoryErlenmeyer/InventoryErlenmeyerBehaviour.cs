using SaguFramework;

namespace EmergenciaQuimica {
	
	public sealed class InventoryErlenmeyerBehaviour : InventoryItemBehaviour {
		
		public override void OnLook() {
			Game.Describe("ErlenmeyerDescription");
		}
		
		public override void OnUseInventoryItem(InventoryItem inventoryItem) {
			Game.Negate();
		}

		protected override string GetTooltip() {
			return Framework.GetText("ErlenmeyerTooltip");
		}

	}
	
}
