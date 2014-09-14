using SaguFramework;

namespace EmergenciaQuimica {
	
	public class ScientistBehaviour : CharacterBehaviour {
		
		public virtual void OnUseInventoryItem(InventoryItem inventoryItem) {
			if (inventoryItem.GetId() == "ProtectionSuit") {
				// TODO
			}
		}
		
		protected override string GetTooltip() {
			return Language.GetText("ScientistTooltip");
		}

	}
	
}
