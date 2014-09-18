using SaguFramework;

namespace EmergenciaQuimica {
	
	public class InventoryProtectionSuitBehaviour : InventoryItemBehaviour {
		
		public override void OnLook() {
			// TODO
		}
		
		public override void OnUseInventoryItem(InventoryItem inventoryItem) {
			// TODO
		}

		protected override string GetTooltip() {
			return Language.GetText("ProtectionSuitTooltip");
		}

	}
	
}
