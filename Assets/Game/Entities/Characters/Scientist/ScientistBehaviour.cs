using SaguFramework;

namespace EmergenciaQuimica {
	
	public class ScientistBehaviour : CharacterBehaviour {
		
		public override void OnUseInventoryItem(InventoryItem inventoryItem) {
			if (inventoryItem.GetId() == "InventoryProtectionSuit") {
				State.AddHint("ScientistHasProtectionSuit");
				Game.RemoveFromInventory("InventoryProtectionSuit");
			}
		}
		
		protected override string GetTooltip() {
			return Language.GetText("ScientistTooltip");
		}

	}
	
}
