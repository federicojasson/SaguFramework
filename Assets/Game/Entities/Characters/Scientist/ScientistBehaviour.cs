using SaguFramework;

namespace EmergenciaQuimica {
	
	public class ScientistBehaviour : CharacterBehaviour {
		
		public override void OnUseInventoryItem(InventoryItem inventoryItem) {
			if (inventoryItem.GetId() == "ProtectionSuit") {
				// TODO: al usar protection suit
			}
		}
		
		protected override string GetTooltip() {
			return Language.GetText("ScientistTooltip");
		}

	}
	
}
