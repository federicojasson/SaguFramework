using SaguFramework;

namespace EmergenciaQuimica {
	
	public class InventoryErlenmeyerBehaviour : InventoryItemBehaviour {
		
		public override void OnLook() {
			// TODO
		}
		
		public override void OnUseInventoryItem(InventoryItem inventoryItem) {
			// TODO
		}

		protected override string GetTooltip() {
			return Language.GetText("ErlenmeyerTooltip");
		}

	}
	
}
