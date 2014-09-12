using SaguFramework;

namespace EmergenciaQuimica {
	
	public class InventoryErlenmeyerBehaviour : InventoryItemBehaviour {

		protected override string GetTooltip() {
			return Language.GetText("InventoryErlenmeyerTooltip");
		}

	}
	
}
