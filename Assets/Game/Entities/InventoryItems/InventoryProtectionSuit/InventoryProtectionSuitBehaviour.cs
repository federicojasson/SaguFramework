using SaguFramework;

namespace EmergenciaQuimica {
	
	public class InventoryProtectionSuitBehaviour : InventoryItemBehaviour {

		protected override string GetTooltip() {
			return Language.GetText("ProtectionSuitTooltip");
		}

	}
	
}
