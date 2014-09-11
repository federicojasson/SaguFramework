using SaguFramework;

namespace EmergenciaQuimica {
	
	public class InventoryErlenmeyerBehaviour : InventoryItemBehaviour {

		public override void OnLook() {}
		
		public override void OnSpeak() {}
		
		public override void OnUseInventoryItem(InventoryItem inventoryItem) {}

		protected override string GetTooltip() {
			return "Erlenmeyer";
		}

	}
	
}
